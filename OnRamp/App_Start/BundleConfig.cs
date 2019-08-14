using System.Web;
using System.Web.Optimization;

namespace OnRamp {
	public class BundleConfig {
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles) {
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/assets/plugins/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
				"~/assets/plugins/jquery-ui/jquery-ui-{version}.custom.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/assets/scripts/custom/jquery.unobtrusive*",
				"~/assets/scripts/custom/jquery.validationEngine*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			//bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
			//    "~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/metronic").Include(
				"~/assets/scripts/core/metronic.js",
				"~/assets/scripts/core/layout.js"));

			bundles.Add(new ScriptBundle("~/bundles/jquery/plugins").Include(
				"~/assets/plugins/jquery-slimscroll/jquery.slimscroll.js",
				"~/assets/plugins/jquery-notific8/jquery.notific8.js",
				"~/assets/plugins/uniform/jquery.uniform.js",
				"~/assets/plugins/select2/select2.js",
				"~/assets/scripts/custom/jquery.dataTables.js",
				"~/assets/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/assets/plugins/bootstrap/js/bootstrap.min.js",
				"~/assets/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.js",
				"~/assets/plugins/bootstrap-fileinput/bootstrap-fileinput.js",
				"~/assets/plugins/bootstrap-switch/js/bootstrap-switch.js"));

			bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
				"~/assets/scripts/custom/jquery.signalR-{version}.js"));

			bundles.Add(new StyleBundle("~/bundles/content").Include(
				"~/assets/plugins/simple-line-icons/simple-line-icons.css",
				"~/assets/plugins/font-awesome/css/font-awesome.css",
				"~/assets/plugins/bootstrap/css/bootstrap.css",
				//"~/assets/css/layout.css",
				"~/assets/css/plugins.css",
				"~/assets/css/components.css",
				//"~/assets/css/themes/default.css",
				"~/assets/layouts/layout/css/layout.min.css",
				"~/assets/layouts/layout/css/themes/darkblue.min.css",
				"~/assets/plugins/uniform/css/uniform.default.css",
				"~/assets/plugins/bootstrap-switch/css/bootstrap-switch.css",
				"~/assets/css/jquery.dataTables.css",
				"~/assets/plugins/datatables/extensions/TableTools/css/dataTables.tableTools.css",
				"~/assets/css/validationEngine.jquery.css",
				"~/assets/plugins/bootstrap-fileinput/bootstrap-fileinput.css",
				"~/assets/plugins/select2/select2.css",
				"~/assets/plugins/bootstrap-daterangepicker/daterangepicker.min.css"));

			bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
				"~/Content/themes/base/jquery.ui.core.css",
				"~/Content/themes/base/jquery.ui.resizable.css",
				"~/Content/themes/base/jquery.ui.selectable.css",
				"~/Content/themes/base/jquery.ui.accordion.css",
				"~/Content/themes/base/jquery.ui.autocomplete.css",
				"~/Content/themes/base/jquery.ui.button.css",
				"~/Content/themes/base/jquery.ui.dialog.css",
				"~/Content/themes/base/jquery.ui.slider.css",
				"~/Content/themes/base/jquery.ui.tabs.css",
				"~/Content/themes/base/jquery.ui.datepicker.css",
				"~/Content/themes/base/jquery.ui.progressbar.css",
				"~/Content/themes/base/jquery.ui.theme.css"));
		}
	}
}
