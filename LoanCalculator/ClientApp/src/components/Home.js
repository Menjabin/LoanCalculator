import React, { Component } from 'react';
import { LoanForm } from './LoanForm';
import { PaybackPlan } from './PaybackPlan';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div class="text-center">
        <h1>Housing Loan</h1>
        <p>Our loans have a fixed rate of 3.5%. Find your amoritization schedule here:</p>
        <LoanForm />
      </div>
    );
  }
}
