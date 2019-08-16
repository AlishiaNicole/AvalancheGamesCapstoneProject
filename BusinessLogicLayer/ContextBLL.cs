﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ContextBLL : IDisposable
    #region Context stuff

    {
        DataAccessLayer.ContextDAL _context = new DataAccessLayer.ContextDAL();
        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
        bool Log(Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
        public ContextBLL()
        {
            try
            {
                string connectionstring;
                connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
                _context.ConnectionString = connectionstring;
            }
            catch (Exception ex) when (Log(ex))
            {
                //this exception does not have a reasonable handler, simply log it
            }
        }
        public void GenerateNotConnected()
        {
            _context.GenerateNotConnected();
        }
        public void GenerateStoredProcedureNotFound()
        {
            _context.GenerateStoredProcedureNotFound();
        }
        public void GenerateParameterNotIncluded()
        {
            _context.GenerateParametersNotIncluded();
        }
        #endregion
        #region UserBLL
        public int CreateUser(string FirstName, string LastName, string UserName, string Email, int PhoneNumber, string SALT, string HASH, DateTime DateOfBirth, int RoleID)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateUser(FirstName, LastName, UserName, Email, PhoneNumber, SALT, HASH, DateOfBirth, RoleID);
            return ProposedReturnValue;
        }
        public int CreateUser(UserBLL user)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateUser(user.FirstName, user.LastName, user.UserName, user.Email, user.PhoneNumber, user.SALT, user.HASH, user.DateOfBirth, user.RoleID);
            return ProposedReturnValue;
        }
        public void UpdateUser(int UserID, string FirstName, string LastName, string UserName, string Email, int PhoneNumber, string SALT, string HASH, DateTime DateOfBirth, int RoleID)
        {
            _context.UpdateUser(UserID, FirstName, LastName, UserName, Email, PhoneNumber, SALT, HASH, DateOfBirth, RoleID);
        }
        public void UpdateUser(UserBLL user)
        {
            _context.UpdateUser(user.UserID, user.FirstName, user.LastName, user.UserName, user.Email, user.PhoneNumber, user.SALT, user.HASH, user.DateOfBirth, user.RoleID);
        }
        public void DeleteUser(int UserID)
        {
            _context.DeleteUser(UserID);
        }
        public void DeleteUser(UserBLL user)
        {
            _context.DeleteUser(user.UserID);
        }
        public UserBLL FindUserByUserID(int UserID)
        {
            UserBLL ProposedReturnValue = null;
            UserDAL DataLayerObject = _context.FindUserByUserID(UserID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public UserBLL FindUserByUserEmail(string Email)
        {
            UserBLL ProposedReturnValue = null;
            UserDAL DataLayerObject = _context.FindUserByUserEmail(Email);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public List<UserBLL> GetUsers(int skip, int take)
        {
            List<UserBLL> ProposedReturnValue = new List<UserBLL>();
            List<UserDAL> ListOfDataLayerObjects = _context.GetUsers(skip, take);
            foreach (UserDAL User in ListOfDataLayerObjects)
            {
                UserBLL BusinessObject = new UserBLL(User);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public List<UserBLL> GetUsersRelatedToRoleID(int RoleID, int skip, int take)
        {
            List<UserBLL> ProposedReturnValue = new List<UserBLL>();
            List<UserDAL> ListOfDataLayerObjects = _context.GetUsersRelatedToRoleID(RoleID, skip, take);
            foreach (UserDAL User in ListOfDataLayerObjects)
            {
                UserBLL BusinessObject = new UserBLL(User);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public int ObtainUserCount()
        {
            int ProposedReturnValue = 0;
            ProposedReturnValue = _context.ObtainUserCount();
            return ProposedReturnValue;
        }
        #endregion
        #region RoleBLL
        public int CreateRole(string RoleName)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateRole(RoleName);
            return ProposedReturnValue;
        }
        public int CreateRole(RoleBLL role)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateRole(role.RoleName);
            return ProposedReturnValue;
        }
        public void UpdateRole(int RoleID, string RoleName)
        {
            _context.UpdateRole(RoleID, RoleName);
        }
        public void UpdateRole(RoleBLL role)
        {
            _context.UpdateRole(role.RoleID, role.RoleName);
        }
        public void DeleteRole(int RoleID)
        {
            _context.DeleteRole(RoleID);
        }
        public void DeleteRole(RoleBLL role)
        {
            _context.DeleteRole(role.RoleID);
        }
        public RoleBLL FindRoleByRoleID(int RoleID)
        {
            RoleBLL ProposedReturnValue = null;
            RoleDAL DataLayerObject = _context.FindRoleByRoleID(RoleID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new RoleBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public List<RoleBLL> GetRoles(int skip, int take)
        {
            List<RoleBLL> ProposedReturnValue = new List<RoleBLL>();
            List<RoleDAL> ListOfDataLayerObjects = _context.GetRoles(skip, take);
            foreach (RoleDAL role in ListOfDataLayerObjects)
            {
                RoleBLL BusinessObject = new RoleBLL(role);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public int ObtainRoleCount()
        {
            int ProposedReturnValue = 0;
            ProposedReturnValue = _context.ObtainRoleCount();
            return ProposedReturnValue;
        }
        #endregion
        #region CommentBLL
        public int CreateComment(string GameComment, int UserID, int GameID, bool Liked)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateComment(GameComment, UserID, GameID, Liked);
            return ProposedReturnValue;
        }
        public int CreateComment(CommentBLL comment)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateComment(comment.GameComment, comment.UserID, comment.GameID, comment.Liked);
            return ProposedReturnValue;
        }
        public void UpdateComment(int CommentID, string GameComment, int UserID, int GameID, bool Liked)
        {
            _context.UpdateComment(CommentID, GameComment, UserID, GameID, Liked);
        }
        public void UpdateComment(CommentBLL comment)
        {
            _context.UpdateComment(comment.CommentID, comment.GameComment, comment.UserID, comment.GameID, comment.Liked);
        }
        public void DeleteComment(int CommentID)
        {
            _context.DeleteComment(CommentID);
        }
        public void DeleteComment(CommentBLL comment)
        {
            _context.DeleteComment(comment.CommentID);
        }
        public CommentBLL FindCommentByCommentID(int CommentID)
        {
            CommentBLL ProposedReturnValue = null;
            CommentDAL DataLayerObject = _context.FindCommentByCommentID(CommentID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new CommentBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public List<CommentBLL> GetComments(int skip, int take)
        {
            List<CommentBLL> ProposedReturnValue = new List<CommentBLL>();
            List<CommentDAL> ListOfDataLayerObjects = _context.GetComments(skip, take);
            foreach(CommentDAL comment in ListOfDataLayerObjects)
            {
                CommentBLL BusinessObject = new CommentBLL(comment);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public List<CommentBLL> GetCommentsRelatedToGameID(int GameID, int skip, int take)
        {
            List<CommentBLL> ProposedReturnValue = new List<CommentBLL>();
            List<CommentDAL> ListOfDataLayerObjects = _context.GetCommentsRelatedToGameID(GameID, skip, take);
            foreach (CommentDAL comment in ListOfDataLayerObjects)
            {
                CommentBLL BusinessObject = new CommentBLL(comment);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public List<CommentBLL> GetCommentsRelatedToUserID(int UserID, int skip, int take)
        {
            List<CommentBLL> ProposedReturnValue = new List<CommentBLL>();
            List<CommentDAL> ListOfDataLayerObjects = _context.GetCommentsRelatedToUserID(UserID, skip, take);
            foreach (CommentDAL comment in ListOfDataLayerObjects)
            {
                CommentBLL BusinessObject = new CommentBLL(comment);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        #endregion
        #region GameBLL
        public int CreateGame(string GameName)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateGame(GameName);
            return ProposedReturnValue;
        }
        public int CreateGame(GameBLL game)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateGame(game.GameName);
            return ProposedReturnValue;
        }
        public void UpdateGame(int GameID, string GameName)
        {
            _context.UpdateGame(GameID, GameName);
        }
        public void UpdateGame(GameBLL game)
        {
            _context.UpdateGame(game.GameID, game.GameName);
        }
        public void DeleteGame(int GameID)
        {
            _context.DeleteGame(GameID);
        }
        public void DeleteGame(GameBLL game)
        {
            _context.DeleteGame(game.GameID);
        }
        public GameBLL FindGameByGameID(int GameID)
        {
            GameBLL ProposedReturnValue = null;
            GameDAL DataLayerObject = _context.FindGameByGameID(GameID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new GameBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public List<GameBLL> GetGames(int skip, int take)
        {
            List<GameBLL> ProposedReturnValue = new List<GameBLL>();
            List<GameDAL> ListOfDataLayerObjects = _context.GetGames(skip, take);
            foreach (GameDAL Game in ListOfDataLayerObjects)
            {
                GameBLL BusinessObject = new GameBLL(Game);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        #endregion
        #region ScoreBLL
        public int CreateScore(int Score, int UserID, int GameID, int AmountPlayed)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateScore(Score, UserID, GameID, AmountPlayed);
            return ProposedReturnValue;
        }
        public int CreateScore(ScoreBLL score)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateScore(score.Score, score.UserID, score.GameID, score.AmountPlayed);
            return ProposedReturnValue;
        }
        public void UpdateScore(int ScoreID, int Score, int UserID, int GameID, int AmountPlayed)
        {
            _context.UpdateScore(ScoreID, Score, UserID, GameID, AmountPlayed);
        }
        public void UpdateScore(ScoreBLL score)
        {
            _context.UpdateScore(score.ScoreID, score.Score, score.UserID, score.GameID, score.AmountPlayed);
        }
        public void DeleteScore(int ScoreID)
        {
            _context.DeleteScore(ScoreID);
        }
        public void DeleteScore(ScoreBLL score)
        {
            _context.DeleteScore(score.ScoreID);
        }
        public ScoreBLL FindScoreByScoreID(int ScoreID)
        {
            ScoreBLL ProposedReturnValue = null;
            ScoreDAL DataLayerObject = _context.FindScoreByScoreID(ScoreID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new ScoreBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public List<ScoreBLL> GetScores(int skip, int take)
        {
            List<ScoreBLL> ProposedReturnValue = new List<ScoreBLL>();
            List<ScoreDAL> ListOfDataLayerObjects = _context.GetScores(skip, take);
            foreach(ScoreDAL score in ListOfDataLayerObjects)
            {
                ScoreBLL BusinessObject = new ScoreBLL(score);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public List<ScoreBLL> GetScoresReltatedToGameID(int GameID, int skip, int take)
        {
            List<ScoreBLL> ProposedReturnValue = new List<ScoreBLL>();
            List<ScoreDAL> ListOfDataLayerObjects = _context.GetScoresRelatedToGameID(GameID, skip, take);
            foreach(ScoreDAL score in ListOfDataLayerObjects)
            {
                ScoreBLL BusinessObject = new ScoreBLL(score);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public List<ScoreBLL> GetScoresReltatedToRoleID(int RoleID, int skip, int take)
        {
            List<ScoreBLL> ProposedReturnValue = new List<ScoreBLL>();
            List<ScoreDAL> ListOfDataLayerObjects = _context.GetScoresRelatedToGameID(RoleID, skip, take);
            foreach (ScoreDAL score in ListOfDataLayerObjects)
            {
                ScoreBLL BusinessObject = new ScoreBLL(score);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public int ObtainScoreCount()
        {
            int ProposedReturnValue = 0;
            ProposedReturnValue = _context.ObtainRoleCount();
            return ProposedReturnValue;
        }
        #endregion
        #region LogEntryBLL
        public int CreateLogEntries(string Message, DateTime TimeOfException, string LogComments, string Category, string ErrorLevel)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateLogEntries(Message, TimeOfException, LogComments, Category, ErrorLevel);
            return ProposedReturnValue;
        }
        public int CreateLogEntries(LogEntriesBLL logEntry)
        {
            int ProposedReturnValue = -1;
            ProposedReturnValue = _context.CreateLogEntries(logEntry.Message, logEntry.TimeOfException, logEntry.LogComments, logEntry.Category, logEntry.ErrorLevel);
            return ProposedReturnValue;
        }
        public void UpdateLogEntries(int LogEntryID, string Message, DateTime TimeOfException, string LogComments, string Category, string ErrorLevel)
        {
            _context.UpdateLogEntries(LogEntryID, Message, TimeOfException, LogComments, Category, ErrorLevel);
        }
        public void UpdateLogEntries(LogEntriesBLL logEntries)
        {
            _context.UpdateLogEntries(logEntries.LogEntryID, logEntries.Message, logEntries.TimeOfException, logEntries.LogComments, logEntries.Category, logEntries.ErrorLevel);
        }

        #endregion
    }
}
