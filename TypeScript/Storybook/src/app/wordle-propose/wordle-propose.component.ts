import { Component, Output, EventEmitter } from '@angular/core';
import { NgForm } from "@angular/forms";

@Component({
  selector: 'app-wordle-propose',
  templateUrl: './wordle-propose.component.html',
  styleUrl: './wordle-propose.component.less',
  //standalone:true
})
export class WordleProposeComponent {
  @Output() newProposition = new EventEmitter<string>();
  viewModel:string="";
  // onSubmit(form: NgForm) {
  //    this.newProposition.emit(this.viewModel);
  // }
   
   onSubmit() {
    this.newProposition.emit(this.viewModel);
 }

}