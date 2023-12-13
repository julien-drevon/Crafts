import { moduleMetadata, type Meta, type StoryObj } from '@storybook/angular';
import { WordleGridComponent, WordleWordModel } from '../app/wordle-grid/wordle-grid.component';
import { WordleMainModule } from "src/app/wordle-main.module";
import { WordleLetterPlacement } from "src/app/word-letter/WordleLetterModel";


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

// export const BadPlacement: Story = {
//   args: {
//     viewModel: {
//       letter:"A",
//       placement: WordleLetterPlacement.badPlacement
//      },
//   },
// };

// export const Wrong: Story = {
//   args: {
//     viewModel: {
//       letter:"A",
//       placement: WordleLetterPlacement.wrong
//      },
//   },
// };