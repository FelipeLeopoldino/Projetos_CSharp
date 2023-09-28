const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 1440,
  viewportHeight: 1055,
  e2e: {
    setupNodeEvents(on, config) {},
    baseUrl: "https://localhost:7112/",
    screenshotOnRunFailure: true,
  },
});
