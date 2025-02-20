import { test, expect } from '@playwright/test';
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const vuetify = createVuetify({
  components,
  directives,
})

test.describe('Home Page', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('http://localhost:8080');
  });

  test('should display the correct title', async ({ page }) => {
    const title = await page.textContent('v-app-bar-title');
    expect(title).toBe('Deutscher Wetterdienst - Weather Alerts');
  });

  test('should display alert details', async ({ page }) => {
    const alertDetails = await page.isVisible('text=Current Alert');
    expect(alertDetails).toBe(true);
  });
});