/**
*Webpack Configurations for Development
*@author Brian Miller <brian.miller@jaxondigital.com>
*@author Joe Nazzaro <joe.nazzaro@jaxondigital.com>

*@description Build steps that are common to dev and production.
*/

const path = require('path');
const autoprefixer = require('autoprefixer');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');

const paths = {
	app: 'app',
	dist: '../wwwroot',
	distFE: 'dist',
};

const IS_DEV = process.env.NODE_ENV !== 'production';

module.exports = {
	target: 'web',
	context: path.join(__dirname, paths.app),

	resolve: {
		extensions: ['.jsx', '.js'],
		alias: {
			// The handlebars alias fixes Handlebars require.extensions errors.
			// See: https://github.com/wycats/handlebars.js/issues/953#issuecomment-239874313
			handlebars: 'handlebars/dist/handlebars.js',
			bootstrap: 'bootstrap/scss/',

			images: path.resolve(__dirname, paths.app, 'assets', 'images'),
			fonts: path.resolve(__dirname, paths.app, 'assets', 'fonts'),
			framework: path.resolve(__dirname, paths.app, 'framework'),
			modules: path.resolve(__dirname, paths.app, 'modules'),
			store: path.resolve(__dirname, paths.app, 'store'),
			styles: path.resolve(__dirname, paths.app, 'styles'),
		},
	},

	entry: {
		main: ['./index.jsx'],
	},

	output: {
		path: path.resolve(__dirname, paths.distFE),
		filename: 'bundle.[name].[hash].js',
	},

	module: {
		rules: [
			// Building all JS and JSX files using Babel to support ES6 syntax and to transform JSX code.
			{
				test: /\.(js|jsx)$/,
				exclude: /node_modules[\\/](?!(dom7|swiper)[\\/]).*/,
				loader: 'babel-loader',
			},

			{
				test: /\.s?css$/,
				use: [
					'css-hot-loader',
					MiniCssExtractPlugin.loader,

					{
						loader: 'css-loader',
						options: {
							sourceMap: IS_DEV,
							importLoaders: 3,
						},
					},

					{
						loader: 'postcss-loader',
						options: {
							sourceMap: IS_DEV,
							plugins: [autoprefixer],
						},
					},

					// Allowing for relative paths in SCSS files instead of having url() statements
					// with a relative path based on the main.scss file
					{
						loader: 'resolve-url-loader',
						options: {
							sourceMap: IS_DEV,
						},
					},

					{
						loader: 'sass-loader',
						options: {
							sourceMap: true, // required for resolve-url-loader
						},
					},
				],
			},

			// Loading fonts imported through font-face declarations in stylesheets.
			{
				test: /[\\/]fonts[\\/].*\.(woff(2)?|ttf|otf|eot|svg)?$/i,
				use: [{
					loader: 'file-loader',
					options: {
						name: '[name].[ext]',
						outputPath: 'assets/fonts/',
						publicPath: '../assets/fonts/',
					},
				}],
			},

			// Enabling importing image files as urls in JS and JSX files.
			{
				test: /\.(webp|svg|gif|png|jpe?g|ico)$/i,
				exclude: [/\.inline\.svg$/, /[\\/]fonts[\\/].*\.svg$/],
				use: [{
					loader: 'file-loader',
					options: {
						name: '[name].[ext]',
						outputPath: 'assets/images/',
						publicPath: '../assets/images/',
					},
				}, {
					loader: 'image-webpack-loader',
					options: {
						disable: process.env.NODE_ENV !== 'production' && process.env.NODE_ENV !== 'staging',
					},
				}],
			},

			{
				test: /\.hbs$/,
				loader: 'handlebars-loader',
				query: {
					inlineRequires: /[\\/]assets[\\/]images[\\/]/ig,
					precompileOptions: {
						knownHelpersOnly: false,
					},
					helperDirs: [
						path.join(__dirname, paths.app, 'templates', 'helpers'),
					],
					partialDirs: [
						path.join(__dirname, paths.app, 'templates', 'partials'),
						path.join(__dirname, paths.app, 'modules'),
					],
				},
			},
		],
	},

	plugins: [
		new CopyWebpackPlugin([{ from: path.resolve(__dirname, paths.app, 'assets/images'), to: 'assets/images' }]),
		new MiniCssExtractPlugin({
			// Options similar to the same options in webpackOptions.output
			filename: 'styles/[name].css',
		}),
	],
};
