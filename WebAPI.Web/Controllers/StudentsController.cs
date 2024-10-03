using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebAPI.Data.Model;

namespace WebAPI.Web.Controllers
{
    public class StudentsController : Controller
    {
       

        public StudentsController()
        {
            
        }

        // GET: Students
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Student> students = new List<Student>();
            using (var https = new HttpClient() )
            {
                using(var repon  = await https.GetAsync("https://localhost:7141/api/Students"))
                {
                    var apirespon = await repon.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<Student>>(apirespon);
                }
            }
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Student studentDetails = new Student();
            using (var https = new HttpClient())
            {
                using (var repon = await https.GetAsync("https://localhost:7141/api/Students/" + id))
                {
                    if (repon.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var apirespon = await repon.Content.ReadAsStringAsync();
                        studentDetails = JsonConvert.DeserializeObject<Student>(apirespon);
                    }
                    else
                    {
                        ViewBag.StudentId = repon.StatusCode;
                    }
                }
            }
            return View(studentDetails);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaSV,Name,Age,Description")] Student student)
        {
            Student studentAdd = new Student();
            using(var https = new HttpClient())
            {
                StringContent stringContent =  new StringContent(JsonConvert.SerializeObject(student),
                    Encoding.UTF8,"application/json");
                using(var repon = await https.PostAsync("https://localhost:7141/api/Students", stringContent))
                {
                    var apirepon = await repon.Content.ReadAsStringAsync();
                    studentAdd = JsonConvert.DeserializeObject<Student>(apirepon);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Student studentDetails = new Student();
            using (var https = new HttpClient())
            {
                using (var repon = await https.GetAsync("https://localhost:7141/api/Students/" + id))
                {
                    if (repon.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var apirespon = await repon.Content.ReadAsStringAsync();
                        studentDetails = JsonConvert.DeserializeObject<Student>(apirespon);
                    }
                    else
                    {
                        ViewBag.StudentId = repon.StatusCode;
                    }
                }
            }
            return View(studentDetails);
        }


        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Student student)
        {
             Student studentupdate = new Student();
             using(var https = new HttpClient())
            {
                var conten = new MultipartFormDataContent();
                conten.Add(new StringContent(student.Id.ToString()), "Id");
                conten.Add(new StringContent(student.MaSV), "MaSV");
                conten.Add(new StringContent(student.Name), "Name");
                conten.Add(new StringContent(student.Age.ToString()), "Age");
                conten.Add(new StringContent(student.Description), "Description");
                //StringContent stringContent = new StringContent(JsonConvert.SerializeObject(student),
                //    Encoding.UTF8, "application/json");
                using (var repon = await https.PutAsync("https://localhost:7141/api/Students", conten))
                {
                    var apirepon= await repon.Content.ReadAsStringAsync();
                    ViewBag.Result = "Sucscess";
                    studentupdate = JsonConvert.DeserializeObject<Student>(apirepon);
                }
            }
             return RedirectToAction("Index");
        }


        // POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
          
        //}
    }
}
