using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Two.Context;
using Two.Models;

namespace Two.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController (DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// Контроллер  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.Include(i=>i.Position).ToListAsync();
          
            return View(users);
        }
        public async Task<IActionResult> Create()
        {
            User user = new User();
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
            return View(user);

        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            user.CreateAt = DateTime.Now;
            user.ModifiedAt = DateTime.Now;
           /* user.PositionId = 1;*/
/*            user.Position.Title = "Developer";*/
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
            return View( user);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(User user)
        {
            if(User is null)
            {
                throw new ArgumentException(nameof(user));
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }


      /*  [HttpPost]
        public async Task<IActionResult> Delete (User user)
        {
            *//*   var user = await  _context.Users.FindAsync(id);*//*
           await _context.Users.FindAsync(user);
              _context.Users.Remove(user);
       
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        *//*     _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*//*
        }*/
    }
}
