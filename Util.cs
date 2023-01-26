// Import correct packages
using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Util
  {
    // Add List parameter to method
    public static void PrintEmployees(List<Employee> employees) 
    {
      for (int i = 0; i < employees.Count; i++) 
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
      }
    }
    public static void MakeCSV(List<Employee> employees)
    {
        // Check to see if folder exists
            if (!Directory.Exists("data")) 
            {
                // If not, create it
                Directory.CreateDirectory("data");
            }
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
                {
                file.WriteLine("ID,Name,PhotoUrl");

                    // Loop over employees
                    for (int i = 0; i < employees.Count; i++)
                    {
                        // Write each employee to the file
                        string template = "{0},{1},{2}";
                        file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                    }
                }
    }
      async public static Task MakeBadges(List<Employee> employees) {
        
        // Layout variables
        int BADGE_WIDTH = 669;
        int BADGE_HEIGHT = 1044;     
        int PHOTO_LEFT_X = 184;
        int PHOTO_TOP_Y = 215;
        int PHOTO_RIGHT_X = 486;
        int PHOTO_BOTTOM_Y = 517;
        int COMPANY_NAME_Y = 150;
        int EMPLOYEE_NAME_Y = 600;
        // int EMPLOYEE_ID_Y = 730;

        using (HttpClient client = new HttpClient())
          {
            for (int i = 0; i < employees.Count; i++)
            {

              SKPaint paint = new SKPaint();
              paint.TextSize = 42.0f;
              paint.IsAntialias = true;
              paint.Color = SKColors.White;
              paint.IsStroke = false;
              paint.TextAlign = SKTextAlign.Center;
              paint.Typeface = SKTypeface.FromFamilyName("Arial");
              SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
              SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

              SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
              SKCanvas canvas = new SKCanvas(badge);

              canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
              canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));

              SKImage finalImage = SKImage.FromBitmap(badge);
              SKData data = finalImage.Encode();
              
              string template = "data/{0}_badge.png";
              data.SaveTo(File.OpenWrite(string.Format(template, employees[i].GetId())));
              
              paint.Color = SKColors.Black;
              paint.Typeface = SKTypeface.FromFamilyName("Courier New");

              // Employee name
              // Company name
              canvas.DrawText(employees[i].GetCompanyName(), BADGE_WIDTH / 2f, COMPANY_NAME_Y, paint);
              canvas.DrawText(employees[i].GetFullName(), BADGE_WIDTH / 2f, EMPLOYEE_NAME_Y, paint);
            }

          }
        
      }
  }

}

// using System;
// using System.IO;
// using System.Net;
// using System.Drawing;
// using System.Collections.Generic;

// namespace CatWorx.BadgeMaker
// {
//     class Util
//     {
//         public static void PrintEmployees(List<Employee> employees)
//         {
//             for (int i = 0; i < employees.Count; i++)
//             {
//                 string template = "{0,-10}\t{1,-20}\t{2}";
//                 Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
//             }
//         }

//         public static void MakeCSV(List<Employee> employees)
//         {
//             // Check to see if folder exists
//             if (!Directory.Exists("data"))
//             {
//                 // If not, create it
//                 Directory.CreateDirectory("data");
//             }
//             using (StreamWriter file = new StreamWriter("data/employees.csv"))
//             {
//                 file.WriteLine("ID,Name,PhotoUrl");

//                 // Loop over employees
//                 for (int i = 0; i < employees.Count; i++)
//                 {
//                     // Write each employee to the file
//                     string template = "{0},{1},{2}";
//                     file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
//                 }
//             }
//         }
//         public static void MakeBadges(List<Employee> employees)
//         {
//             // Layout variables
//             int BADGE_WIDTH = 669;
//             int BADGE_HEIGHT = 1044;

//             int COMPANY_NAME_START_X = 0;
//             int COMPANY_NAME_START_Y = 110;
//             int COMPANY_NAME_WIDTH = 100;
            
//             int PHOTO_START_X = 184;
//             int PHOTO_START_Y = 215;
//             int PHOTO_WIDTH = 302;
//             int PHOTO_HEIGHT = 302;

//             int EMPLOYEE_NAME_START_X = 0;
//             int EMPLOYEE_NAME_START_Y = 560;
//             int EMPLOYEE_NAME_WIDTH = BADGE_WIDTH;
//             int EMPLOYEE_NAME_HEIGHT = 100;

//             int EMPLOYEE_ID_START_X = 0;
//             int EMPLOYEE_ID_START_Y = 690;
//             int EMPLOYEE_ID_WIDTH = BADGE_WIDTH;
//             int EMPLOYEE_ID_HEIGHT = 100;

//             // Graphics objects
//             StringFormat format = new StringFormat();
//             format.Alignment = StringAlignment.Center;
//             int FONT_SIZE = 32;
//             Font font = new Font("Arial", FONT_SIZE);
//             Font monoFont = new Font("Courier New", FONT_SIZE);

//             SolidBrush brush = new SolidBrush(Color.Black);

//             // Instance of WebClient, disposed after code block has run
//             using(WebClient client = new WebClient())
//             {
//                 for (int i =0; i < employees.Count; i++)
//                 {
//                     // Create badge with employee image
//                     Image photo = Image.FromStream(client.OpenRead(employees[i].GetPhotoUrl()));
//                     Image background = Image.FromFile("badge.png");
//                     Image badge = new Bitmap(BADGE_WIDTH, BADGE_HEIGHT);
//                     Graphics graphic = Graphics.FromImage(badge);
//                     graphic.DrawImage(background, new Rectangle(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
//                     graphic.DrawImage(photo, new Rectangle(PHOTO_START_X, PHOTO_START_Y, PHOTO_WIDTH, PHOTO_HEIGHT));

//                     // Add company name
//                     graphic.DrawString(employees[i].GetCompanyName(), font, new SolidBrush(Color.White), new Rectangle(
//                         COMPANY_NAME_START_X,
//                         COMPANY_NAME_START_Y,
//                         BADGE_WIDTH,
//                         COMPANY_NAME_WIDTH
//                     ),
//                     format
//                     );

//                     // Add employee name
//                     graphic.DrawString(employees[i].GetName(), font, brush, new Rectangle(
//                         EMPLOYEE_NAME_START_X,
//                         EMPLOYEE_NAME_START_Y,
//                         EMPLOYEE_NAME_WIDTH,
//                         EMPLOYEE_NAME_HEIGHT
//                     ),
//                     format
//                     );

//                     // Add employee id
//                     graphic.DrawString(employees[i].GetId().ToString(), monoFont, brush, new Rectangle(
//                         EMPLOYEE_ID_START_X,
//                         EMPLOYEE_ID_START_Y,
//                         EMPLOYEE_ID_WIDTH,
//                         EMPLOYEE_ID_HEIGHT
//                     ),
//                     format
//                     );

//                     // Save badge
//                     string template = "data/{0}_badge.png";
//                     badge.Save(string.Format(template, employees[i].GetId()));
//                 }
//             }
//         }
//     }
// }
