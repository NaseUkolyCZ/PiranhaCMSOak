using NSpec;
using PiranhaCMSOak.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oak;

namespace PiranhaCMSOak.Tests
{
    class describe_BaseController : nspec
    {
        private static CultureInfo EN_US = new CultureInfo("en-US");
        private static CultureInfo CS_CZ = new CultureInfo("cs-CZ");

        BaseController controller;

        void before_each()
        {
            controller = new BaseController();
        }

        void specify_get_invariant_language_from_null()
        {
            CultureInfo ci = controller.GetCurrentUserCI(null);

            ci.DisplayName.should_be(CultureInfo.InvariantCulture.DisplayName);
        }

        void specify_get_invariant_language_from_empty_array()
        {
            CultureInfo ci = controller.GetCurrentUserCI(new string[] {} );

            ci.DisplayName.should_be(CultureInfo.InvariantCulture.DisplayName);
        }

        void specify_get_invariant_language_from_nonexisting_language()
        {
            CultureInfo ci = controller.GetCurrentUserCI(new string[] { "bla-BLA" });

            ci.DisplayName.should_be(CultureInfo.InvariantCulture.DisplayName);
        }

        void specify_get_csCZ_language_from_CS()
        {
            CultureInfo ci = controller.GetCurrentUserCI(new string[] { "cs" });

            ci.DisplayName.should_be(CS_CZ.DisplayName);
        }
        void specify_get_enUS_language_from_EN()
        {
            CultureInfo ci = controller.GetCurrentUserCI(new string[] { "en" });

            ci.DisplayName.should_be(EN_US.DisplayName);
        }

    }
}
