using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        [Route("HomeStudent")]// định danh action
        [Route("Student")]
        [Route("Student/ListAll")]
        [Route("Liệt-Kê-Danh-Sách-Sinh-viên")]
        [Route("File/Download-file")]
        [Route("Student/List")]
        public IActionResult ListAll()
        {
            List<Student> listStudent = new List<Student>()
            {
                new Student { Id = 1, Name = "Đức Đạt", age = 19, gender = true, ImgUrl = "https://chiemtaimobile.vn/images/companies/1/%E1%BA%A2nh%20Blog/avatar-facebook-dep/Anh-avatar-hoat-hinh-de-thuong-xinh-xan.jpg?1704788263223", Des = "mô tả thông tin sinh vien" },
                new Student { Id = 2, Name = "Thùy trâm", age = 25, gender = false, ImgUrl = "https://hoanghamobile.com/tin-tuc/wp-content/uploads/2024/07/anh-avatar-dep-cho-con-gai-2.jpg", Des = "mô tả thông tin sinh vien" },
                new Student { Id = 3, Name = "Nhã Phương", age = 20, gender = false, ImgUrl = "https://dongvat.edu.vn/upload/2025/01/avatar-anime-nu-de-thuong-02.webp", Des = "mô tả thông tin sinh vien" },
                new Student { Id = 4, Name = "Thanh viễn", age = 23, gender = true, ImgUrl = "https://cdn11.dienmaycholon.vn/filewebdmclnew/public/userupload/files/Image%20FP_2024/avatar-cute-45.jpg", Des = "mô tả thông tin sinh vien" },
                new Student { Id = 5, Name = "Hoàng Việt", age = 19, gender = true, ImgUrl = "https://i.pinimg.com/564x/79/d3/1e/79d31e406fe3d3d7322b18666184911d.jpg", Des = "mô tả thông tin sinh vien" }
            };
            return View(listStudent); }

        public IActionResult LisOnlyStudent()
        {
            if (!Request.Query.ContainsKey("id"))
            {
                return BadRequest("Student Id is not provided");
            }
            int id = Convert.ToInt32(Request.Query["id"]);
            if (id<1||id>1000) 
            {
                return NotFound("Student Id is not match");
            }
            return Content("thong tin sinh vien:" + id, "text/html");
        }
        
        public FileResult Index()
        {
            return File("linq.pdf", "application/pdf");
        }
        public string ListOnlyOne()
        {
            return "liệt kê một sinh viên có id cụ thể";
        }
        public string AddStudent()
        {
            return "Thêm thông tin một sinh viên";
        }
        public string DelStudentt()
        {
            return "xoa thong tin mot sinh vien";
        }
        [Route("Edit-student")]
        public IActionResult Editstudent()
        {
            return LocalRedirect("~/Home/Index");
        }
        public IActionResult LisOnlyStudent([FromQuery]int? id)
        {
            if(!id.HasValue)
            {
                return BadRequest("student id is not provided");
            }
            return Content($"Thong tin sinh vien {id}");
        }
    }
}
