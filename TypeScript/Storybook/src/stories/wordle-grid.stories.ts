import { moduleMetadata, type Meta, type StoryObj } from '@storybook/angular';

import { WordleMainModule } from "src/app/wordle-main.module";
import { WordleLetterPlacement } from "src/app/word-letter/WordleLetterModel";
import { WordleGridComponent, WordleWordModel } from "src/app/wordle-grid/wordle-grid.component";



//More on how to set up stories at: https://storybook.js.org/docs/angular/writing-stories/introduction
const meta: Meta<WordleGridComponent> = {
  title: 'Example/WordleGridComponent',
  component: WordleGridComponent,
  tags: ['autodocs'], decorators: [
    moduleMetadata({
      //👇 Imports both components to allow component composition with Storybook
      declarations: [ ],
      imports: [WordleMainModule],
    }),
  ],
  render: (args: WordleGridComponent) => ({
    props: {
      backgroundColor: null,
      ...args,
    },
  }),
  argTypes: {
  //   viewModel: {
  //    letter:'A',
  //    placement: WordleLetterPlacement.good
  //   },
   },
};

export default meta;
type Story = StoryObj<WordleGridComponent>;

// More on writing stories with args: https://storybook.js.org/docs/angular/writing-stories/args
export const Empty: Story = {
  args: {
    // viewModel: {
    //   letter:"",
    //   placement: WordleGridComponent.empty
    //  },
  },
};

export const Good: Story = {
  args: {
    viewModel: [
      new WordleWordModel([{letter:"A", placement:WordleLetterPlacement.good},{letter:"B", placement:WordleLetterPlacement.good},{letter:"C", placement:WordleLetterPlacement.wrong},{letter:"D", placement:WordleLetterPlacement.wrong},{letter:"A", placement:WordleLetterPlacement.badPlacement}]),
      new WordleWordModel(),
      new WordleWordModel(),
      new WordleWordModel(),
      new WordleWordModel()
    ]
  },
};
export const CompleteGrid: Story = {
  args: {
    viewModel: [
      new WordleWordModel([{letter:"A", placement:WordleLetterPlacement.good},{letter:"B", placement:WordleLetterPlacement.good},{letter:"C", placement:WordleLetterPlacement.wrong},{letter:"D", placement:WordleLetterPlacement.wrong},{letter:"A", placement:WordleLetterPlacement.badPlacement}]),
      new WordleWordModel([{letter:"A", placement:WordleLetterPlacement.good},{letter:"B", placement:WordleLetterPlacement.good},{letter:"E", placement:WordleLetterPlacement.wrong},{letter:"A", placement:WordleLetterPlacement.good},{letter:"T", placement:WordleLetterPlacement.wrong}]),
      new WordleWordModel([{letter:"A", placement:WordleLetterPlacement.good},{letter:"B", placement:WordleLetterPlacement.good},{letter:"C", placement:WordleLetterPlacement.good},{letter:"D", placement:WordleLetterPlacement.badPlacement},{letter:"A", placement:WordleLetterPlacement.good}]),
      new WordleWordModel([{letter:"A", placement:WordleLetterPlacement.good},{letter:"B", placement:WordleLetterPlacement.good},{letter:"C", placement:WordleLetterPlacement.wrong},{letter:"D", placement:WordleLetterPlacement.wrong},{letter:"A", placement:WordleLetterPlacement.badPlacement}]),
      new WordleWordModel([{letter:"A", placement:WordleLetterPlacement.good},{letter:"B", placement:WordleLetterPlacement.good},{letter:"C", placement:WordleLetterPlacement.good},{letter:"D", placement:WordleLetterPlacement.good},{letter:"A", placement:WordleLetterPlacement.good}])
    ]
  },
};