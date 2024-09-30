/**
*Webpack Configurations for Development
*@author Brian Miller <brian.miller@jaxondigital.com>
*@author Joe Nazzaro <joe.nazzaro@jaxondigital.com>

*@description Build steps specific to dev environment. Initialize  dev server with hot module replacement.
*/

const path = require("path");
const merge = require("webpack-merge");
const { NamedModulesPlugin, HotModuleReplacementPlugin } = require("webpack");
const WebfontPlugin = require("webfont-webpack-plugin").default;

const serverSetup = require("./server/dev-server");
const config = require("./webpack.config");

const paths = {
	app: "app",
	dist: '../wwwroot/assets',
	distFE: 'dist',

	helpers: path.join(__dirname, "app/templates/helpers"),
	partials: path.join(__dirname, "app/templates/partials"),
	modules: path.join(__dirname, "app/modules"),
};

module.exports = merge(config, {
	mode: "development",

	watchOptions: {
		aggregateTimeout: 300,
		ignored: /node_modules/,
	},

	devtool: "inline-source-map",

	// Setting up a development server with hot module replacement.
	devServer: {
		contentBase: [
			path.join(__dirname, paths.distFE),
			path.join(__dirname, paths.app, "assets"),
			path.join(__dirname, paths.app, "etc"),
		],

		// Using local IP address, so the application is accessable from other devices on the
		// network (i.e. a virtual machine or mobile device).
		host: "0.0.0.0", // required for useLocalIp to work
		useLocalIp: true,
		port: 3125,
		hot: true,
		open: true,

		before: (app, server) => {
			serverSetup(app, server);
		},

		// Shows build errors and warnings
		overlay: {
			warnings: true,
			errors: true,
		},

		watchContentBase: true,
	},

	optimization: {
		// Splitting the built JS into two bundles: main and vendor.
		// This takes all the imported libraries from node_modules and builds it
		// into the vendor bundle. This results in faster development as it doesn't
		// need to rebuild all the libraries files.
		splitChunks: {
			cacheGroups: {
				commons: {
					test: /[\\/]node_modules[\\/]/,
					name: "vendor",
					chunks: "all",
				},
			},
		},
	},

	plugins: [
		new NamedModulesPlugin(), // causes the relative path of the module to be displayed
		new HotModuleReplacementPlugin(), // enables Hot Module Replacement, otherwise known as HMR

		// Creating an icon font based on SVG files in the icon-svgs directory
		new WebfontPlugin({
			fontName: "icon-font",
			files: path.resolve(__dirname, paths.app, "assets/icon-svgs/*.svg"),
			dest: path.resolve(__dirname, paths.app, "assets/fonts/icon-font"),

			destTemplate: path.resolve(
				__dirname,
				paths.app,
				"styles/framework"
			),
			template: path.resolve(
				__dirname,
				paths.app,
				"assets/icon-svgs/_icon-font.scss"
			),
			templateFontPath: "../../assets/fonts/icon-font",

			normalize: true,
			fontHeight: 1000,
		}),
	],
});
