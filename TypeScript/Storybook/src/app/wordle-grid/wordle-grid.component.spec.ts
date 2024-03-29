import type { ComponentFixture} from "@angular/core/testing";
import { TestBed } from "@angular/core/testing";
import { WordleGridComponent } from "./wordle-grid.component";

import { WordleLetterPlacement } from "../word-letter/WordleLetterModel";
import { WordleMainModule } from "../wordle-main.module";



describe("WordleGridComponent", () => {
  let component: WordleGridComponent;
  let fixture: ComponentFixture<WordleGridComponent>;
  let nativeElements:HTMLElement;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ],
        imports:[WordleMainModule],
      });
      fixture = TestBed.createComponent(WordleGridComponent);
      component = fixture.componentInstance;   
      nativeElements = fixture.nativeElement ;
      fixture.detectChanges();
    });
    
    it("should create", () => {
      expect(component).toBeTruthy();
    });
    
    it("Grid should have 5 column and line and bind letter", () => {    
      expect(nativeElements.getElementsByClassName("wordle-empty-letter")).toHaveLength(25); 
      
      component.viewModel[3].line[1].letter="A";
      component.viewModel[3].line[1].placement= WordleLetterPlacement.good;
      fixture.detectChanges();
      expect(nativeElements.getElementsByClassName("wordle-good-letter")).toHaveLength(1); 
      
    });
  });
  