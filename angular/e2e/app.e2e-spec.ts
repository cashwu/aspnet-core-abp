import { CashTestTemplatePage } from './app.po';

describe('CashTest App', function() {
  let page: CashTestTemplatePage;

  beforeEach(() => {
    page = new CashTestTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
