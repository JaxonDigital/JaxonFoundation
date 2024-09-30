/**
*Webpack Configurations for Development
*@author Brian Miller <brian.miller@jaxondigital.com>
*@author Joe Nazzaro <joe.nazzaro@jaxondigital.com>

*@description Build steps specific to prod environment. Minify .CSS and .JS files.
*/

const path = require('path');
const webpack = require('webpack');
const merge = require('webpack-merge');
const cssnano = require('cssnano');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const TerserPlugin = require('terser-webpack-plugin');
const OptimizeCssPlugin = require('optimize-css-assets-webpack-plugin');
const HandlebarsPlugin = require('handlebars-webpack-plugin');
const handlebarsLayout = require('handlebars-layouts');
const repeatHelper = require('handlebars-helper-repeat');
const beautify = require('js-beautify');

const config = require('./webpack.config');

const paths = {
	app: 'app',
	dist: 'dist',
};

const IS_STAGING = process.env.NODE_ENV === 'staging';

module.exports = merge(config, {
	mode: 'production',

	output: {
		filename: 'bundle.[name].js',
	},

	devtool: false,

	optimization: {
		minimizer: [
			// Minifying JS and CSS files
			new TerserPlugin({
				sourceMap: true,
			}),
			new OptimizeCssPlugin({
				cssProcessor: cssnano,
			}),
		],
	},

	plugins: [
		new CleanWebpackPlugin({
			cleanOnceBeforeBuildPatterns: ['**/*', '!built-templates', '!built-templates/**/*'],

		}), // deleting the dist directory for a clean setup

		// Ignore grid-overlay unless it's a staging environment
		(IS_STAGING ? () => { } : new webpack.IgnorePlugin({
			resourceRegExp: /[\\/]grid-overlay/,
		})),

		new webpack.optimize.LimitChunkCountPlugin({
			maxChunks: 1,
		}),

		new HandlebarsPlugin({
			htmlWebpackPlugin: false,

			// path to hbs entry file(s)
			entry: path.join(__dirname, paths.app, 'templates', !IS_STAGING ? '!(grid-test).hbs' : '*.hbs'),

			// output path and filename(s). This should lie within the webpacks output-folder
			// if ommited, the input filepath stripped of its extension will be used
			output: path.join(__dirname, paths.dist, 'built-templates', '[name].html'),

			// or add it as filepath to rebuild data on change using webpack-dev-server
			data: {
				isProduction: !IS_STAGING,
			},

			helpers: {
				projectHelpers: path.join(__dirname, paths.app, 'templates/helpers', '*.js'),
			},

			// globbed path to partials, where folder/filename is unique
			partials: [
				path.join(__dirname, paths.app, 'templates/partials/**/*.hbs'),
				path.join(__dirname, paths.app, 'modules/**/*.hbs'),
			],

			getPartialId(partialPath) {
				const name = partialPath.split(/[\\/]app[\\/](modules|templates[\\/]partials)[\\/]/)[2];
				return name
					.replace(/\\/g, '/')
					.replace(/^\/*/, '')
					.replace(/\.[^.]*$/, '');
			},

			onBeforeSetup(Handlebars) {
				Handlebars.registerHelper(handlebarsLayout(Handlebars));
				Handlebars.registerHelper('repeat', repeatHelper);
			},

			onBeforeSave(Handlebars, html) {
				// Replacing asset paths to the templates
				return beautify.html(
					html
						.replace(/ src=("|').*..\/assets\//gi, (match, p1) => {
							return ` src=${p1}../assets/`;
						})
						.replace(/url\(("|').*..\/assets\//gi, (match, p1) => {
							return `url(${p1}../assets/`;
						}),
					{
						end_with_newline: true,
						indent_size: 4,
						indent_with_tabs: true,
					},
				);
			},
		}),
	],
});
