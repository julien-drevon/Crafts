import type { Meta, StoryObj } from '@storybook/angular';
import { WordleLetterComponent } from "src/app/word-letter/wordle-letter.component";
import { WordleLetterPlacement } from "src/app/word-letter/WordleLetterModel";


//More on how to set up stories at: https://storybook.js.org/docs/angular/writing-stories/introduction
const meta: Meta<WordleLetterComponent> = {
  title: 'Example/WordLetterComponent',
  component: WordleLetterComponent,
  tags: ['autodocs'],
  render: (args: WordleLetterComponent) => ({
    props: {
      backgroundColor: null,
      ...args,
    },
  }),
  argTypes: {
    viewModel: {
     letter:'A',
     placement: WordleLetterPlacement.good
    },
  },
};

export default meta;
type Story = StoryObj<WordleLetterComponent>;

// More on writing stories with args: https://storybook.js.org/docs/angular/writing-stories/args
export const Empty: Story = {
  args: {
    viewModel: {
      letter:"",
      placement: WordleLetterPlacement.empty
     },
  },
};

export const Good: Story = {
  args: {
    viewModel: {
      letter:"A",
      placement: WordleLetterPlacement.good
     },
  },
};

export const BadPlacement: Story = {
  args: {
    viewModel: {
      letter:"A",
      placement: WordleLetterPlacement.badPlacement
     },
  },
};

export const Wrong: Story = {
  args: {
    viewModel: {
      letter:"A",
      placement: WordleLetterPlacement.wrong
     },
  },
};