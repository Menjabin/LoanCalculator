import React, { Component } from 'react';
import { RepaymentPlan } from './RepaymentPlan';

export class LoanForm extends Component {
    static displayName = LoanForm.name;

    constructor(props) {
        super(props);
        // Initialize the state with default values
        this.state = {
            amount: 100000,
            years: 1,
            content: null
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    // Dynamically update the form whenever the values are changed
    handleChange(event) {
        // Each input has a name attribute corresponding to a state variable
        this.setState({ [event.target.name]: event.target.value });
    }

    // We can now view the resulting plan
    handleSubmit(event) {
        this.setState({ content: <RepaymentPlan amount={this.state.amount} years={this.state.years} /> });
    }

    render() {
        return (
            <>
                {/* This div contains the whole input form */}
                <div class="col-12 text-center">
                    {/* Each "calculatorSlider" controls a separate value. This one is for the loan amount */}
                    <div class="calculatorSlider">
                        <label class="test">Loan Amount</label>
                        {/* The slider has two buttons beside it that also adjust the value */}
                        <div class="calculatorSlider-slider">
                            <input id="amountRange" name="amount" type="range" tabIndex="-1" min="100000" max="15000000" step="25000" value={this.state.amount} onChange={this.handleChange} />
                        </div>
                        {/* The user can simply enter the value in this text field. The slider and text field will update each other when changed */}
                        <div class="calculatorSlider-number">
                            <input id="amount" name="amount" type="text" step="25000" value={this.state.amount} onChange={this.handleChange} />
                            <span>kr</span>
                        </div>
                    </div>
                    {/* This div is for the loan term */}
                    <div class="calculatorSlider">
                        <label class="test">Loan Term</label>
                        {/* This slider and text field are also connected to the same values */}
                        <div class="calculatorSlider-slider">
                            <input id="termRange" name="years" type="range" tabIndex="-1" min="1" max="30" step="1" value={this.state.years} onChange={this.handleChange} />
                        </div>
                        <div class="calculatorSlider-number">
                            <input id="term" name="years" type="text" min="1" max="30" step="1" value={this.state.years} onChange={this.handleChange} />
                            <span>yrs</span>
                        </div>
                    </div>
                    {/* Calculate a plan with the current values */}
                    <button onClick={this.handleSubmit}>Calculate plan</button>
                </div>
                {this.state.content}
            </>
        );
    }
}
