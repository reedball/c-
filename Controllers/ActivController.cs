using System.Collections.Generic;
using System.Linq;
using CBelt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CBelt.Controllers
{
    public class ActivController : Controller
    {
        private MyContext DbContext;
        public ActivController(MyContext context){
            DbContext = context;
        } 
        [HttpGet("home")]
        public IActionResult All()
        {
            if(HttpContext.Session.GetInt32("userId")==null){
                return RedirectToAction("Index", "Home");
            }
            else {
                List<Activ> allActivs = DbContext.Activs
                .OrderBy(a => a.Date)
                .Include(b => b.Creator)
                .Include(c => c.GuestList)
                .ThenInclude(p => p.Participator)
                .ToList();
                ViewBag.UserId = HttpContext.Session.GetInt32("userId");
                return View(allActivs);
            }
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost("activs/create")]
        public IActionResult Create(Activ newActiv)
        {
            if(ModelState.IsValid)
            {
                newActiv.Creator = DbContext.Users.FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("userId"));
                DbContext.Activs.Add(newActiv);
                DbContext.SaveChanges();
                return RedirectToAction("All"); 
            }
            return View("New");
        }
        [HttpGet("activity/{activId}")]
        public IActionResult OneActivity (int activId)
        {
            var oneActiv = DbContext.Activs
            .Include(a => a.Creator)
            .Include(guest => guest.GuestList)
            .ThenInclude(user => user.Participator)
            .FirstOrDefault(activ => activ.ActivityId == activId);
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            // grabbing the list of comments where the ActivityId from the comment equal that of the Id from the URL
            List<Comment> Comments = DbContext.Comments
            //include the user so we can display the user who posted particular comment
            .Include(c => c.Commenter)
            .Include(d => d.ActivCommented)
            .Where(c => c.ActivityId == activId)
            .ToList();
            //
            OneActivView view = new OneActivView();
            view.oneActiv = oneActiv;
            view.CommentsforActiv = Comments;
            return View(view);
        }
        [HttpPost("activity/delete/{activId}")]
        public IActionResult Delete(int activId)
        {
            var oneActiv = DbContext.Activs.FirstOrDefault(activ => activ.ActivityId == activId);
            DbContext.Activs.Remove(oneActiv);
            DbContext.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpPost("activity/join/{activId}")]
        public IActionResult Respond (int activId)
        {
            var DidParticipate = DbContext.Participates.Where(w => w.ActivityId == activId).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId"));
            if (DidParticipate == null)
            {
                Participate newParticipate = new Participate();
                newParticipate.UserId = (int)HttpContext.Session.GetInt32("userId");
                newParticipate.ActivityId = activId;
                DbContext.Add(newParticipate);
                DbContext.SaveChanges();

            }
            else
            {
                DbContext.Remove(DidParticipate);
                DbContext.SaveChanges();
            }
            return RedirectToAction("All");
        }
        [HttpPost("activity/{activId}/comment")]
        public IActionResult NewComment(OneActivView fromform, int activId)
        {
            Activ activToComment = DbContext.Activs.FirstOrDefault(act => act.ActivityId == activId);
            if(ModelState.IsValid){
                //specifying the foreign key to matching the activity it is related to
                fromform.newComment.ActivityId=activId;
                //fk for the user that commented
                fromform.newComment.UserId = (int)HttpContext.Session.GetInt32("userId");
                //creating newComment
                DbContext.Add(fromform.newComment);
                //actually adding the newComment to the database
                DbContext.SaveChanges();
                return RedirectToAction("OneActivity", new{activId=activId});
            }
            return View("OneActivity", activToComment);
        }

    }
}