﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using AvalancheGamesWeb.Models;

namespace AvalancheGamesWeb.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Page(int? PageNumber, int? PageSize)
        {
            int PageN = (PageNumber.HasValue) ? PageNumber.Value : 0;
            int PageS = (PageSize.HasValue) ? PageSize.Value : ApplicationConfig.DefaultPageSize;
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<GameBLL> Model = new List<GameBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalCount = ctx.ObtainGameCount();
                    Model = ctx.GetGames(PageN * PageS, PageS);

                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Errorr");
            }
        }

        //List<SelectListItem> GetUserItems()
        //{
        //    List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
        //    using (ContextBLL ctx = new ContextBLL())
        //    {
        //        List<UserBLL> users = ctx.GetUsers(0, 25);
        //        foreach (UserBLL user in users)
        //        {
        //            SelectListItem item = new SelectListItem();
        //            item.Value = user.UserID.ToString();
        //            item.Text = user.Email;
        //            ProposedReturnValue.Add(item);
        //        }
        //    }
        //    return ProposedReturnValue;
        //}
        //List<SelectListItem> GetGameItems()
        //{
        //    List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
        //    using (ContextBLL ctx = new ContextBLL())
        //    {
        //        List<GameBLL> games = ctx.GetGames(0, 25);
        //        foreach (GameBLL game in games)
        //        {
        //            SelectListItem item = new SelectListItem();
        //            item.Value = game.GameID.ToString();
        //            item.Text = game.GameName;
        //            ProposedReturnValue.Add(item);
        //        }
        //    }
        //    return ProposedReturnValue;
        //}
        // GET: Game
        public ActionResult Index()
        {
            List<GameBLL> Model = new List<GameBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.PageNumber = 0;
                    ViewBag.PageSize = ApplicationConfig.DefaultPageSize;
                    ViewBag.TotalCount = ctx.ObtainGameCount();
                    Model = ctx.GetGames(0, ViewBag.PageSize);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(Model);//model is list of roles, name of view is same as method name
        }

        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            GameBLL Game;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    Game = ctx.FindGameByGameID(id);
                    if (null == Game)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(Game);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            GameBLL defGame = new GameBLL();
            defGame.GameID = 0;
            return View(defGame);
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(BusinessLogicLayer.GameBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateGame(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            GameBLL Game;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    Game = ctx.FindGameByGameID(id);
                    if (null == Game)
                    {
                        return View("ItemNotFound");

                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(Game);
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BusinessLogicLayer.GameBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }// TODO: Add update logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.UpdateGame(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.exception = ex;
                return View("Error");
            }
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            GameBLL Game;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    Game = ctx.FindGameByGameID(id);
                    if (null == Game)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(Game);
        }

        // POST: Game/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BusinessLogicLayer.GameBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                // TODO: Add delete logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.DeleteGame(id);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }
        public ActionResult Snake()
        {
            return View();
        }


        public ActionResult SnakeResult()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SnakeResult(ScoreBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateScore(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult SnakeResult(int id)
        {

            using (ContextBLL ctx = new ContextBLL())
            {
                ScoreBLL thisScore = new ScoreBLL();
                    // string email = Session["AUTHEmail"].ToString();
                    var name = ctx.FindUserByUserName(User.Identity.Name);
                    thisScore.Score = id;
                    thisScore.UserID = name.UserID;
                    thisScore.GameID = 1;
                    ViewBag.score = id;
                ctx.CreateScore(thisScore);
                //return View("SnakeScore");
                // return View(thisScore);
                return RedirectToAction("Index", "MyScores");
            }
            }






        public ActionResult PongBall()
        {
            return View();
        }


        public ActionResult PongBallResult()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PongBallResult(ScoreBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateScore(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult PongBallResult(int id)
        {

            using (ContextBLL ctx = new ContextBLL())
            {
                ScoreBLL thisScore = new ScoreBLL();
                // string email = Session["AUTHEmail"].ToString();
                var name = ctx.FindUserByUserName(User.Identity.Name);
                thisScore.Score = id;
                thisScore.UserID = name.UserID;
                thisScore.GameID = 2;
                ViewBag.score = id;
                ctx.CreateScore(thisScore);
                //return View("SnakeScore");
                // return View(thisScore);
                return RedirectToAction("Index", "MyScores");
            }
        }
        public ActionResult Floaty()
        {
            return View();
        }


        public ActionResult FloatyResult()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FloatyResult(ScoreBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateScore(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult FloatyResult(int id)
        {

            using (ContextBLL ctx = new ContextBLL())
            {
                ScoreBLL thisScore = new ScoreBLL();
                // string email = Session["AUTHEmail"].ToString();
                var name = ctx.FindUserByUserName(User.Identity.Name);
                thisScore.Score = id;
                thisScore.UserID = name.UserID;
                thisScore.GameID = 3;
                ViewBag.score = id;
                ctx.CreateScore(thisScore);
                //return View("SnakeScore");
                // return View(thisScore);
                return RedirectToAction("Index", "MyScores");
            }
        }
        //[HttpPost]
        //public ActionResult SnakeResult(ScoreBLL collection)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(collection);
        //        }
        //        using (ContextBLL ctx = new ContextBLL())
        //        {
        //            ctx.CreateScore(collection);
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception Ex)
        //    {
        //        ViewBag.Exception = Ex;
        //        return View("Error");
        //    }
        //}
        //public ActionResult PongBall()
        //{
        //    return View();
        //}
        //public ActionResult PongBallResult(int id)
        //{
        //    ViewBag.score = id;
        //    return View("PongballScore");
        //}
        //public ActionResult Floaty()
        //{
        //    return View();
        //}
        //public ActionResult FloatyResult(int id)
        //{
        //    ViewBag.score = id;
        //    return View("FloatyScore");
        //}

        //public ActionResult SnakeResult()
        //{
        //    return View();
        //}
        //public ActionResult SnakeResult(int id)
        //{
        //    ViewBag.score = id;
        //    return View("SnakeScore");
        //}
    }
}
