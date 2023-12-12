import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WordLetterComponent } from './word-letter.component';

describe('WordLetterComponent', () => {
  let component: WordLetterComponent;
  let fixture: ComponentFixture<WordLetterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WordLetterComponent]
    });
    fixture = TestBed.createComponent(WordLetterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
