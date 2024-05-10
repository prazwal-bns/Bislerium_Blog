using System.ComponentModel.DataAnnotations.Schema;
using BlogCw.Areas.Identity.Data;

namespace BlogCw.Models;

public class NotificationModel
{
    [Column("Id")]
    public int NotificationId { get; set; }

    [Column("Title")]
    public string NotificationTitle { get; set; }

    [Column("Description")]
    public string NotificationDescription { get; set; }

    [Column("Status")]
    public bool IsRead { get; set; }

    [Column("UserId")]
    public string UserId { get; set; }
}