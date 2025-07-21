using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

public class ValvePressureCalculator
{
    // Helper class for Body materials from 'Min & Max temp of BA' sheet
    public class BodyTempRange
    {
        public string MaterialFullName { get; set; }
        public double MinTempC { get; set; }
        public double MaxTempC { get; set; }
    }

    // Helper class for Seat and Seal materials from matrix-style sheets
    public class ComponentTempRange
    {
        public string Material { get; set; }
        public string ClassRating { get; set; }
        public double MinTempC { get; set; }
        public double MaxTempC { get; set; }
    }

    // Helper class for 'Body Matl Group number-B16.34' sheet
    public class GroupMapping
    {
        public string BodyMaterial { get; set; }
        public string GroupNumber { get; set; }
    }

    // Helper class for 'Group number vs pressure' sheet
    public class PressureRating
    {
        public string GroupNumber { get; set; }
        public string ClassRating { get; set; }
        public double TempC { get; set; }
        public double PressureBar { get; set; }
    }

    // Main program entry point
    public void Main()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        string filePath = "D:\\Applications\\DSA\\DSA\\TMBV_ID_plate_Pressure_temp_details_Short form_BA.xlsx";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: The file '{filePath}' was not found.");
            return;
        }

        using var package = new ExcelPackage(new FileInfo(filePath));

        // Load all necessary worksheets
        var bodyTempSheet = package.Workbook.Worksheets["Min & Max temp of BA"];
        var seatTempSheet = package.Workbook.Worksheets["Sheet1"]; 
        var sealTempSheet = package.Workbook.Worksheets["Sheet2"];
        var groupSheet = package.Workbook.Worksheets["Body Matl Group number-B16.34"];
        var pressureSheet = package.Workbook.Worksheets["Group number vs pressure"];

        // Load data into lists
        var bodyTempRanges = LoadBodyMaterialTempRanges(bodyTempSheet);
        var seatTempRanges = LoadComponentTempRanges(seatTempSheet);
        var sealTempRanges = LoadComponentTempRanges(sealTempSheet);
        var groupMap = LoadGroupMappings(groupSheet);
        var pressureRatings = LoadPressureRatings(pressureSheet);

        // --- Input Parameters ---
        string bodyMatFullName = "ASTM A182 Gr.F53";
        string seatMat = "RPTFE";
        string sealMat = "FFKM FF200-75";
        string classRating = "300";

        // Step 2: Get temperature range for each component
        var body = bodyTempRanges.FirstOrDefault(m => m.MaterialFullName.Trim() == bodyMatFullName);
        var seat = seatTempRanges.FirstOrDefault(m => m.Material.Trim() == seatMat && m.ClassRating.Trim() == classRating);
        var seal = sealTempRanges.FirstOrDefault(m => m.Material.Contains(sealMat) && m.ClassRating.Trim() == classRating);

        if (body == null || seat == null || seal == null)
        {
            Console.WriteLine("Error: Could not find temp data for one or more materials.");
            return;
        }

        double maxValveTempC = Math.Min(body.MaxTempC, Math.Min(seat.MaxTempC, seal.MaxTempC));
        double minValveTempC = Math.Max(body.MinTempC, Math.Max(seat.MinTempC, seal.MinTempC));

        var groupMapping = groupMap.FirstOrDefault(g => !string.IsNullOrWhiteSpace(g.BodyMaterial) && bodyMatFullName.Contains(g.BodyMaterial.Trim()));

        if (groupMapping == null)
        {
            Console.WriteLine($"Error: Could not find a matching Group Number for material '{bodyMatFullName}'.");
            return;
        }
        string groupNumber = groupMapping.GroupNumber;
        // ==========================================================

        // Steps 4 & 5: Interpolate pressure and convert units
        double pressureMinTempBar = InterpolatePressure(groupNumber, classRating, minValveTempC, pressureRatings);
        double pressureMaxTempBar = InterpolatePressure(groupNumber, classRating, maxValveTempC, pressureRatings);

        double minTempF = minValveTempC * 9 / 5 + 32;
        double maxTempF = maxValveTempC * 9 / 5 + 32;
        double pressureMinTempPsi = pressureMinTempBar * 14.5038;
        double pressureMaxTempPsi = pressureMaxTempBar * 14.5038;

        // Final Output
        Console.WriteLine("--- Valve Pressure-Temperature Range ---");
        Console.WriteLine($"{pressureMinTempBar:F1} bar @ {minValveTempC}°C\t\t{pressureMaxTempBar:F1} bar @ {maxValveTempC}°C");
        Console.WriteLine($"{pressureMinTempPsi:F0} psig @ {minTempF:F0}°F\t\t{pressureMaxTempPsi:F0} psig @ {maxTempF:F0}°F");
    }

    #region Data Loading Functions

    // Loads from 'Min & Max temp of BA' sheet
    public static List<BodyTempRange> LoadBodyMaterialTempRanges(ExcelWorksheet sheet)
    {
        var list = new List<BodyTempRange>();
        for (int row = 3; row <= sheet.Dimension.End.Row; row++) // Data starts on row 3
        {
            if (double.TryParse(sheet.Cells[row, 3].Value?.ToString(), out double minTemp) &&
                double.TryParse(sheet.Cells[row, 4].Value?.ToString(), out double maxTemp))
            {
                list.Add(new BodyTempRange
                {
                    MaterialFullName = sheet.Cells[row, 2].Text,
                    MinTempC = minTemp,
                    MaxTempC = maxTemp
                });
            }
        }
        return list;
    }

    // Loads from matrix sheets like 'Sheet1' (Seats) and 'Sheet2' (Seals)
    // Generic function for matrix sheets like 'Sheet1' (Seats) and 'Sheet2' (Seals)
    public static List<ComponentTempRange> LoadComponentTempRanges(ExcelWorksheet sheet)
    {
        var list = new List<ComponentTempRange>();
        var classRatings = new Dictionary<int, string>(); // Stores Column Index -> Class Rating

        // Step 1: Read the Class Ratings from Row 2, starting at Column 3 (C)
        // This implements your requirement exactly.
        for (int col = 3; col <= sheet.Dimension.End.Column; col += 2) // Step by 2 (Min, Max)
        {
            var classValue = sheet.Cells[2, col].Text;
            if (!string.IsNullOrWhiteSpace(classValue))
            {
                classRatings.Add(col, classValue);
            }
        }

        // Step 2: Read the data rows starting from row 4
        for (int row = 4; row <= sheet.Dimension.End.Row; row++)
        {
            var materialName = sheet.Cells[row, 2].Text; // Material name from Column B
            if (string.IsNullOrWhiteSpace(materialName)) continue;

            // Loop through the class ratings we found in the header
            foreach (var kvp in classRatings)
            {
                int minCol = kvp.Key;
                int maxCol = kvp.Key + 1;
                string classRating = kvp.Value;

                if (double.TryParse(sheet.Cells[row, minCol].Value?.ToString(), out double minTemp) &&
                    double.TryParse(sheet.Cells[row, maxCol].Value?.ToString(), out double maxTemp))
                {
                    list.Add(new ComponentTempRange
                    {
                        Material = materialName,
                        ClassRating = classRating,
                        MinTempC = minTemp,
                        MaxTempC = maxTemp
                    });
                }
            }
        }
        return list;
    }
    // Loads from 'Body Matl Group number-B16.34'
    public static List<GroupMapping> LoadGroupMappings(ExcelWorksheet sheet)
    {
        var list = new List<GroupMapping>();
        // Start from row 3 to skip headers
        for (int row = 3; row <= sheet.Dimension.End.Row; row++)
        {
            // Get the material name from Column 2
            var materialName = sheet.Cells[row, 2].Text;

            // Skip the row if the material name is empty
            if (string.IsNullOrWhiteSpace(materialName)) continue;

            list.Add(new GroupMapping
            {
                // CORRECTED: Read BodyMaterial from Column 2
                BodyMaterial = materialName.Trim(),

                // CORRECTED: Read GroupNumber from Column 4
                GroupNumber = sheet.Cells[row, 3].Text.Trim()
            });
        }
        return list;
    }

    // Loads from the 'Group number vs pressure' matrix sheet
    public static List<PressureRating> LoadPressureRatings(ExcelWorksheet sheet)
    {
        var list = new List<PressureRating>();
        var classRatings = new Dictionary<int, string>();
        for (int col = 7; col <= sheet.Dimension.End.Column; col++)
        {
            var classValue = sheet.Cells[3, col].Text;
            if (!string.IsNullOrWhiteSpace(classValue)) classRatings.Add(col, classValue);
        }
        for (int row = 4; row <= sheet.Dimension.End.Row; row++)
        {
            var groupNumber = sheet.Cells[row, 2].Text;
            if (string.IsNullOrWhiteSpace(groupNumber)) continue;
            if (double.TryParse(sheet.Cells[row, 6].Value?.ToString(), out double tempC))
            {
                foreach (var kvp in classRatings)
                {
                    if (double.TryParse(sheet.Cells[row, kvp.Key].Value?.ToString(), out double pressureBar))
                    {
                        list.Add(new PressureRating
                        {
                            GroupNumber = groupNumber,
                            ClassRating = kvp.Value,
                            TempC = tempC,
                            PressureBar = pressureBar
                        });
                    }
                }
            }
        }
        return list;
    }

    // Interpolates pressure for a given temperature
    public static double InterpolatePressure(string groupNumber, string classRating, double temp, List<PressureRating> ratings)
    {
        var relevantRatings = ratings
            .Where(r => r.GroupNumber.Trim() == groupNumber.Trim() && r.ClassRating.Trim() == classRating.Trim())
            .OrderBy(r => r.TempC)
            .ToList();

        if (!relevantRatings.Any()) return 0;

        var p1 = relevantRatings.LastOrDefault(p => p.TempC <= temp);
        var p2 = relevantRatings.FirstOrDefault(p => p.TempC >= temp);

        if (p1 == null) return p2.PressureBar;
        if (p2 == null) return p1.PressureBar;
        if (p1 == p2) return p1.PressureBar;

        if (p1.TempC == p2.TempC) return p1.PressureBar;

        return p1.PressureBar + (temp - p1.TempC) * (p2.PressureBar - p1.PressureBar) / (p2.TempC - p1.TempC);
    }
    #endregion
}