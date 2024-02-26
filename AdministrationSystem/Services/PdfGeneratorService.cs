using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using Microsoft.AspNetCore.Mvc;
using AdministrationSystem.Models;
using Firebase.Storage;

namespace AdministrationSystem.Services
{
    public class PdfGeneratorService
    {
        public PdfGeneratorService(Courses courses) 
        {
            this.courses = courses;
        }

        private Courses courses;

        public MemoryStream pdfAttendanceList(List<User> users, string courseId)
        {
            var stream = new MemoryStream();
            Course course = courses.Get(courseId);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(2, Unit.Centimetre);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(text => text.FontSize(14));

                    page.Header()
                        .Text($"Lista obecnosci: {course.Name + " " + course.Location + "\n" + course.Day + " " + course.Time}")
                            .FontSize(22)
                            .Bold();

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
                .GeneratePdf(stream);
            return stream;
        }

        public async Task PushFile(MemoryStream stream, Course course)
        {
            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                FirebaseStorage storage = new FirebaseStorage("tigerbytes-2ffa5.appspot.com", new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult("pyfh6tC0C3KKXhqfnu7T2LKmpt4Ptq6OuzDGQnW7")
                });
                var task = storage.Child($"AttendanceLists/{course.Location}/{course.Name}/{course.Day + "_" + course.StartingTime}.pdf").PutAsync(stream);
                await task;
            }
            catch (Exception ex) { }
        }
    }
}
