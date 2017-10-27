using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject.Model.Model;

namespace BlogProject.UI.MVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            Post[] posts = Post.FindAll();

            if (posts.Count() > 0)
            {
                ViewData["AllPosts"] = posts;
                ViewData["LatestPosts"] = Post.FindLatestPost();
                return View();
            }
            else
                return Create();
        }

        [HttpPost]
        public ActionResult CreateComment(int postId)
        {
            Post post = Post.Find(postId);

            Comment comment = new Comment();
            comment.Post = post;
            comment.Author = Request.Form["Author"];
            comment.DateAdded = DateTime.Now;
            comment.Text = Request.Form["Comment"];

            comment.Save();

            return Detail(post.Id);
        }

        public ActionResult Detail(int id)
        {
            ViewData["AllPosts"] = Post.FindAll();

            ViewData["LatestPost"] = Post.Find(id);

            return View("Index");
        }

        public ActionResult Create()
        {
            return View("AddPost");
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Post post = new Post();
            post.DateAdded = DateTime.Now;
            post.Subject = Request.Form["Subject"];
            post.Text = Request.Form["Content"]; ;
            post.Save();

            return Detail(post.Id);
        }
    }
}