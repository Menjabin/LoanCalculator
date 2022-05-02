import React, { Component } from 'react';
import { LoanForm } from './LoanForm';
import { PaybackPlan } from './PaybackPlan';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Find your payback plan</h1>
        <p>This site will help you create a plan for monthly payback on housing loans</p>
        <LoanForm />
      </div>
    );
  }
}
