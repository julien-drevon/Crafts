import type { StorybookConfig } from "@storybook/angular";

const config: StorybookConfig = {
  stories: ["../src/**/*.mdx", "../src/**/*.stories.@(js|jsx|mjs|ts|tsx)"],
  addons: [
    "@storybook/addon-links",
    "@storybook/addon-essentials",
    "@storybook/addon-interactions",
  ],
  framework: {
    name: "@storybook/angular",
    options: {},
  },
  docs: {
    autodocs: "tag",
  },
};
export default config;

// const TsconfigPathsPlugin = require('tsconfig-paths-webpack-plugin');

// module.exports = {
//   webpackFinal: async (config) => {
//     config.resolve.plugins = [
//       ...(config.resolve.plugins || []),
//       new TsconfigPathsPlugin({
//         extensions: config.resolve.extensions,
//       }),
//     ];
//     return config;
//   },
// };