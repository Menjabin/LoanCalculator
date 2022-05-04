import React, { Component } from 'react';
import { LoanForm } from './LoanForm';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div class="text-center justify-content-center">
        <h1>Mortgage Calculator</h1>
        <p>Our mortgages have a fixed annual rate of 3.5%. Find your repayment plan here:</p>
        <LoanForm />
      </div>
    );
  }
}
