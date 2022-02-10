﻿using KitapEvi_DataAccess.DATA;
using KitapEvi_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KitapEvi.Controllers
{
    public class KategoriController : Controller
    {
        private readonly KitapEviContext _db;
        public KategoriController(KitapEviContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Kategori> kList = _db.Kategoriler.ToList();
            return View(kList);
        }
        public IActionResult Update_Insert(int? id)
        {
            Kategori obj = new Kategori();
            if (id==null)
            {
                return View(obj);
            }
            obj = _db.Kategoriler.FirstOrDefault(x => x.KategoriID == id);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //add-migration ekle
        //update-database
        [HttpPost]
        [ValidateAntiForgeryToken]//Güvenlik amacıyla atılan isteklerin gerçek kişiler tarafından gelenlere cevap vermesini sağlar
        public IActionResult Update_Insert(Kategori obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.KategoriID==0)
                {
                    //create işlemi
                    _db.Kategoriler.Add(obj);
                }
                else
                {
                    //update
                    _db.Kategoriler.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.Kategoriler.FirstOrDefault(x => x.KategoriID == id);
            _db.Kategoriler.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction ("Index");
        }

        public IActionResult CokluEkleme3()
        {
            List<Kategori> Klist = new List<Kategori>();
            for (int i = 0; i < 3; i++)
            {
                Klist.Add(new Kategori { KategoriAdi = Guid.NewGuid().ToString() });
            }
            _db.Kategoriler.AddRange(Klist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CokluEkleme10()
        {
            List<Kategori> Klist = new List<Kategori>();
            for (int i = 0; i < 10; i++)
            {
                Klist.Add(new Kategori { KategoriAdi = Guid.NewGuid().ToString() });
            }
            _db.Kategoriler.AddRange(Klist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CokluSilme3()
        {
            IEnumerable<Kategori> klist = _db.Kategoriler.OrderByDescending(x=>x.KategoriID).Take(3).ToList();
            _db.Kategoriler.RemoveRange(klist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CokluSilme10()
        {
            IEnumerable<Kategori> klist = _db.Kategoriler.OrderByDescending(x => x.KategoriID).Take(10).ToList();
            _db.Kategoriler.RemoveRange(klist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
} 