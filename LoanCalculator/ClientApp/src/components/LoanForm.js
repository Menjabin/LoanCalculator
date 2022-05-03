import React, { Component } from 'react';
import { PaybackPlan } from './PaybackPlan';

export class LoanForm extends Component {
    static displayName = LoanForm.name;

    constructor(props) {
        super(props);
        this.state = { amount: 100000, years: 1, submitted: false };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        this.setState({ submitted: true });
    }

    render() {
        let content = this.state.submitted
            ? <PaybackPlan amount={this.state.amount} rate="3.5" months={this.state.years * 12} />
            : []

        return (
            <>
                <div class="col-12 col-lg-10 text-center">
                    <div class="calculatorSlider">
                        <label class="" for="amount">Loan Amount</label>
                        <div class="calculatorSlider-slider">
                            <button class="calculatorSlider-slider-minus" tabIndex="-1">
                                <span>-</span>
                            </button>
                            <input id="amountRange" name="amount" type="range" tabIndex="-1" min="100000" max="15000000" step="25000" value={this.state.amount} onChange={this.handleChange} />
                            <button class="calculatorSlider-slider-plus" tabIndex="-1">
                                <span>+</span>
                            </button>
                        </div>
                        <div class="calculatorSlider-number">
                            <input id="amount" name="amount" type="text" step="25000" value={this.state.amount} onChange={this.handleChange} />
                            <span>kr</span>
                        </div>
                    </div>
                    <div class="calculatorSlider">
                        <label class="" for="term">Loan Term</label>
                        <div class="calculatorSlider-slider">
                            <button class="calculatorSlider-slider-minus" tabIndex="-1">
                                <span>-</span>
                            </button>
                            <input id="termRange" name="years" type="range" tabIndex="-1" min="1" max="30" step="1" value={this.state.years} onChange={this.handleChange} />
                            <button class="calculatorSlider-slider-plus" tabIndex="-1">
                                <span>+</span>
                            </button>
                        </div>
                        <div class="calculatorSlider-number">
                            <input id="term" name="years" type="text" step="1" value={this.state.years} onChange={this.handleChange} />
                            <span>years</span>
                        </div>
                    </div>
                    <button onClick={this.handleSubmit}>Calculate plan</button>
                </div>
                {content}
            </>
        );
    }
}
