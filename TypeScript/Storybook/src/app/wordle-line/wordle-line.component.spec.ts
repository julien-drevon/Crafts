import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WordleLineComponent } from './wordle-line.component';

describe('WordleLineComponent', () => {
  let component: WordleLineComponent;
  let fixture: ComponentFixture<WordleLineComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WordleLineComponent]
    });
    fixture = TestBed.createComponent(WordleLineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });

  
});
