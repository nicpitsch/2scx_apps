using DotNetNuke.Security;
using DotNetNuke.Web.Api;
using System.Web.Http;
using ToSic.SexyContent.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;

public class PortfolioController : SxcApiController
{

  [HttpGet]
  [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Anonymous)]
  [ValidateAntiForgeryToken]
  public IEnumerable<dynamic> Portfolios(string sortMode)
  {
      var result = AsDynamic(App.Data["Portfolio"]);
      var portfolios = from item in result select new {
          Title = item.Title,
          EntityId = item.EntityId,
          Description = item.Description,
          Date = item.DateCreated,
          DateCreated = String.Format("{0:dd.MM.yyyy}", item.DateCreated),
          Images = getPortfolioImages(item.Images),
          Priority = item.Priority != null ? item.Priority : (decimal)0.0,
          Modified = item.Modified,
          SortMode = sortMode,
      };
      // Handle sorting
      // Titel (↑ aufsteigend):Title asc
      // Titel (↓ absteigend):Title desc
      // Erstellung-Datum (↑ aufsteigend):Date asc
      // Erstellung-Datum (↓ absteigend):Date desc
      // Manuelle Reihenfolge (↑ aufsteigend):Manual asc
      // Manuelle Reihenfolge (↓ absteigend):Manual desc
      switch(sortMode)
      {
        case "Title asc":
          portfolios = portfolios.OrderBy(c => c.Title);
          break;
        case "Title desc":
          portfolios = portfolios.OrderByDescending(c => c.Title);
          break;
        case "Date asc":
          portfolios = portfolios.OrderBy(c => c.Date);
          break;
        case "Date desc":
          portfolios = portfolios.OrderByDescending(c => c.Date);
          break;
        case "Manual asc":
          portfolios = portfolios.OrderBy(c => c.Priority).ThenBy(c => c.Title);
          break;
        case "Manual desc":
          portfolios = portfolios.OrderByDescending(c => c.Priority).ThenBy(c => c.Title);
          break;
      }
      return portfolios;
  }

  [HttpGet]
  private dynamic getPortfolioImages(IEnumerable<dynamic> imageList) {
    var images = new List<dynamic>();
    foreach (var item in imageList) {
      var image = AsDynamic(App.Data["e_Image"].List[item.EntityId]);
      var imagefullinfo = new {
        Title = image.title,
        EntityId = image.EntityId,
        File = image.File,
        Priority = image.Priority,
        Deleted = image.Deleted,
        Internal = image.File.Substring(0, "http".Length) != "http" ? true : false
      };
      images.Add(imagefullinfo);
    }
    return images;
  }

  [HttpGet]
  [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Anonymous)]
  [ValidateAntiForgeryToken]
  public dynamic Images()
  {
      var result = AsDynamic(App.Data["e_Image"]);
      var images = from item in result select new {
          Title = item.Title,
          EntityId = item.EntityId,
          File = item.File,
          Priority = item.Priority,
          Deleted = item.Deleted
      };
      return images;
  }

  [HttpGet]
  [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Anonymous)]
  [ValidateAntiForgeryToken]
  public dynamic Image(int id)
  {
      var item = AsDynamic(App.Data["e_Image"].List[id]);
      return new {
          Title = item.Title,
          EntityId = item.EntityId,
          File = item.File,
          Priority = item.Priority,
          Deleted = item.Deleted
      };
  }

}
