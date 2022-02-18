module.exports = {
  devServer: {
    proxy: "https://localhost:7208/",
    host: "localhost",
  },
  css: {
    loaderOptions: {
      sass: {
        additionalData: `
        @import "@/styles/main.scss";
        `,
      },
    },
  },
};
