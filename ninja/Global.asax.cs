using AutoMapper;
using ninja.model.Entity;
using ninja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ninja
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Agrego Automapper Config
            Mapper.Initialize(cfg =>
            {
                //Domain=> VM 
                cfg.CreateMap<Invoice, InvoiceViewModel>()
                    .ForMember(dest => dest.Details, opts => opts.MapFrom(src => src.GetDetail()));
                cfg.CreateMap<InvoiceDetail, InvoiceDetailViewModel>();                

                //VM => Domain
                /*
                 Id Property is the same that Invoice Number, and assign this in create mode
                 In edit i have the Id and work with that for edit Invoice number otherwise i cant because its posibly change another invoice.
                 */
                cfg.CreateMap<InvoiceViewModel, Invoice>()
                    .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type.ToUpper()))
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id == 0 ? src.InvoiceNumber : src.Id));
                cfg.CreateMap<InvoiceDetailViewModel, InvoiceDetail>();
            });
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
