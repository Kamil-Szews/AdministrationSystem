using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF;
using QuestPDF.Elements;
using AdministrationSystem;
using System.Collections.Generic;
using QuestPDF.Helpers;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Previewer;
using AdministrationSystem.Models;

namespace AdministrationSystem.Services
{
    public class PdfGeneratorService
    {
        public PdfGeneratorService(Courses courses) 
        {
            this.courses = courses;
        }

        private Courses courses;

        public void pdfAttendanceList(List<User> users, string courseId)
        {
            Course course = courses.GetCourse(courseId);
            string courseName = course.Name + " " + course.Location + " " + course.Day + " " + course.Time;
            string currentTime =
                DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString();
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(2, Unit.Centimetre);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(text => text.FontSize(20));

                    page.Header()
                        .Text($"Lista obecnosci grupy: {courseName}").FontSize(30).Bold();

                    page.Content()
                        .Column(x =>
                        {
                            int iterator = 0;
                            foreach(User user in users)
                            {
                                iterator++;
                                string userName = iterator.ToString() + ". " + user.Name + " " + user.Surname;
                                x.Item().Text($"{userName}");
                            }
                        });
                });
            })
                .GeneratePdf("test.pdf");
            //$"{courseName}_{currentTime}"
        }
    }
}
