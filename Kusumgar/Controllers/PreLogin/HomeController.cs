﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kusumgar.Models.PreLogin;

using KusumgarCrossCutting.Logging;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kusumgar.Controllers.PreLogin
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Landing Page of Kusumgar ERP.
        /// Check whether user is logged in and active. 
        /// If YES, redirect user to post login page.
        /// If NO, show user same landing page with user friendly message.
        /// </summary>
        /// <returns></returns>

        public ActionResult Index(LoginViewModel loginViewModel)
        {
            try
            {
                if (User.Identity.IsAuthenticated && Session["User"] != null)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    if (TempData["FriendlyMessage"] != null)
                    {
                        loginViewModel.Friendly_Message.Add((FriendlyMessageInfo)TempData["FriendlyMessage"]);
                    }

                    return View("Index", loginViewModel);
                }
            }
            catch (Exception ex)
            {
                loginViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                return View("Index", loginViewModel);
            }
        }

        #region SaveFileOnServer

        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var fileName1 = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);

                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }

        #endregion

        #region DragAndDrop

        public ActionResult DragAndDrop()
        {
            return View();
        }

        #endregion
    }
}
