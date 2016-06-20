﻿namespace ICT4_Participation_ASP.Models.Objects
{
    public enum TransportationType
    {
        Nvt,
        Trein,
        Bus,
        Auto,
        Fiets,
        Benenwagen
    }

    public enum QueryId
    {
        GetAllHelpRequests,
        GetUserHelpRequests,
        GetUserHelpRequest,
        GetUserLogin,
        GetUserLoginByBarcode,
        GetAdminLogin,
        GetAccountID,
        GetAcceptedVolunteers,
        GetVOGVolunteers,
        GetAllReviews,
        GetChatMessagesFromHelprequest,
        GetAllReviewsVolunteer,
        GetVolunteersHelprequest,
        GetAcceptedHelpRequests,
        GetPendingVolunteers,
        WarnUser,
        BlockUser,
        CompleteHelpRequest,
        HelpRequestAccept,
        HelpRequestDecline,
        AcceptedVolunteer,
        UpdateUser,
        UpdateVolunteer,
        UpdateCommentReview,
        UnWarnUser,
        UnsubscribeUser,
        DenyVolunteer,
        DeleteReview,
        DeleteHelpRequest,
        InsertHelprequest,
        InsertReview,
        InsertAccount,
        InsertUser,
        InsertVolunteer,
        InsertNeedy,
        InsertAdmin,
        InsertChatMessage,
        InsertUserHelprequest,
        InsertReport
    }
}