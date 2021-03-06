﻿using Autofac;
using Dotnet.CastleWindsor;
using Dotnet.Autofac;
using Dotnet.Configurations;
using Dotnet.Dependency;
using Dotnet.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Castle.Windsor;

namespace Dotnet.Test
{
    public class BootStrapper
    {
        private void Run()
        {
            //Autofac Builder
            var builder = new ContainerBuilder();
            var windsorContainer = new WindsorContainer();
            Configuration.Create()
                //.UseAutofac(builder)
                .UseCastleWindsor(windsorContainer)
                .RegisterCommonComponent()
                .UseJson4Net()
                .UseLog4Net()
                .UseProtoBuf()
                .AutofacBuild();
            //var container = builder.Build();
            //Configuration.Instance.AutofacBuild(container);


            //缓存设置
            //Configuration.Instance.UseMemoryCache();

            //Configuration.Instance.CacheConfigureAll(cache =>
            //{
            //    cache.DefaultAbsoluteExpireTime = TimeSpan.FromHours(2);
            //});

            //Configuration.Instance.CacheConfigure("Cache1", cache =>
            //{
            //    cache.DefaultAbsoluteExpireTime = TimeSpan.FromMinutes(5);
            //});

            var cacheManager = IocManager.GetContainer().Resolve<ICacheManager>();
            var cache1 = cacheManager.GetCache("cache1");
            ITypedCache<int, string> cache2 = cacheManager.GetCache<int, string>("cache2");

            //获取具体某个cache值
            var user = cacheManager.GetCache("user").Get<long, AutoMapper.TestUser>(1, x => null);
            var order = cacheManager.GetCache("order").Get("100", x => null);
        }


        [Fact]
        public void StartTest()
        {
            Configuration.Create()
              .UseCastleWindsor(new WindsorContainer())
              .RegisterCommonComponent();

        }

    }
}
