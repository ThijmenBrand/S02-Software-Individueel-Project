import { test, expect, Page } from "@playwright/test";

test.beforeEach(async ({ page }) => {
  page.goto("http://localhost:8080/#/");

  //fill out form
  await page.fill("input[name=email]", "testUser@thijmenbrand.nl");
  await page.fill("input[name=password]", "Welkom01");
  await page.locator("#login").click();
  await page.waitForNavigation();
});

test.describe("Project - 1.2.x", () => {
  test("Een gebruiker kan een project aanmaken - 1.2.1", async ({ page }) => {
    await page.locator("#add-new-project").click();
    await expect(page.locator(".el-message-box")).toBeVisible();
    await page.locator(".el-input__inner").fill("test-project");
    await page.locator("text=Create").click();
  });

  // test("Een gebruiker kan een project verwijderen - 1.2.2", async ({
  //   page,
  // }) => {});
});
