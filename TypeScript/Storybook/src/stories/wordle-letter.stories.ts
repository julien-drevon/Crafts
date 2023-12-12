import type { Meta, StoryObj } from '@storybook/angular';
import { WordleLetterPlacement } from "src/app/word-letter/WordleLetterModel";
import { WordLetterComponent } from "src/app/word-letter/word-letter.component";

//More on how to set up stories at: https://storybook.js.org/docs/angular/writing-stories/introduction
const meta: Meta<WordLetterComponent> = {
  title: 'Example/WordLetterComponent',
  component: WordLetterComponent,
  tags: ['autodocs'],
  render: (args: WordLetterComponent) => ({
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
type Story = StoryObj<WordLetterComponent>;

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