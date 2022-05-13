import { test, expect, Page } from "@playwright/test";

test.beforeEach(async ({ page }) => {
  page.goto("http://localhost:8080/#/");
  await page.fill("input[name=email]", "testUser@thijmenbrand.nl");
  await page.fill("input[name=password]", "Welkom01");
  await page.locator("#login").click();
  await page.waitForNavigation();
});

test.describe("Login 1.1.x", () => {
  test("Een gebruiker kan inloggen - 1.1.1", async ({ page }) => {
    await expect(page).toHaveURL("http://localhost:8080/#/home");
  });
});
