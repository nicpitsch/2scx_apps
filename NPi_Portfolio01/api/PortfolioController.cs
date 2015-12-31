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
  public dynamic Portfolios()
  {
      var result = AsDynamic(App.Data["Portfolio"]);
      var portfolios = from item in result select new {
          Title = item.Title,
          EntityId = item.EntityId,
          Description = item.Description,
          DateCreated = String.Format("{0:dd.MM.yyyy}", item.DateCreated),
          Images = getPortfolioImages(item.Images)
      };
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
