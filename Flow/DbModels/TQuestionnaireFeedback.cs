using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TQuestionnaireFeedback
{
    public int QuestionnaireFeedbackId { get; set; }

    public int? TopicId { get; set; }

    public int? QuestionnaireId { get; set; }

    public int? QuestionId { get; set; }

    public string? Conversition { get; set; }

    public string? Summary { get; set; }

    public string? Answer { get; set; }
}
