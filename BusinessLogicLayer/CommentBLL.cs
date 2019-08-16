﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CommentBLL
    {
        public CommentBLL()
        {

        }
        #region direct properties
        public int CommentID { get; set; }
        public string GameComment { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
        public bool Liked { get; set; }
        #endregion
        #region indirect properties 
        public string GameName { get; set; }
        public string Email { get; set; }
        #endregion
        public CommentBLL(DataAccessLayer.CommentDAL dal)
        {
            this.CommentID = dal.CommentID;
            this.GameComment = dal.GameComment;
            this.UserID = dal.UserID;
            this.GameID = dal.GameID;
            this.Liked = dal.Liked;
            this.GameName = dal.GameName;
            this.Email = dal.Email;


        }
        public override string ToString()
        {
            return $"CommentID: {CommentID} GameComment: {GameComment} UserID: {UserID} GameID: {GameID} Liked: {Liked} GameName: {GameName} Email: {Email}";
        }
    }
}