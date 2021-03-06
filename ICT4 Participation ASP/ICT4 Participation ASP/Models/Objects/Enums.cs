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
        GetAcceptedUsers,
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
        AcceptVolunteer,
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
        InsertReport,
        GetNeedy,
        GetReviewsFromHelpRequest,
        GetVolunteersHelprequested,
        GetReviewFromHelpRequestUser,
        DeleteReviews,
        GetAcceptedVolunteersNoHulprequest,
        GetAllVolunteerHelpRequests,
        GetAllVolunteerHelpRequestsReviews,
        GetSkills,
        GetLastHelprequestID,
        InsertHelprequestSkill,
        InsertVolunteerSkill,
        GetAllHelpRequestsInc,
        GetVolunteerSkills,
        GetFilteredHelpRequests,
        ResetUserWarned,
        GetUserWarned
    }
}