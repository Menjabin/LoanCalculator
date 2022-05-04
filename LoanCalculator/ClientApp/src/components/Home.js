import React, { Component } from 'react';
import { LoanForm } from './LoanForm';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div class="text-center">
        <h1>Mortgage Calculator</h1>
        <p>Our loans have a fixed rate of 3.5%. Find your amortization schedule here:</p>
        <LoanForm />
      </div>
    );
  }
}
