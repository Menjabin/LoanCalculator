import React, { Component } from 'react';
import { PaybackPlan } from './PaybackPlan';

export class LoanForm extends Component {
    static displayName = LoanForm.name;

    constructor(props) {
        super(props);
        this.state = { amount: 0, months: 0, submitted: false };

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
            ? <PaybackPlan amount={this.state.amount} rate="3.5" months={this.state.months} />
            : []

        return (
            <>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        <b>Amount</b><br />
                        <input name="amount" type="number" value={this.state.amount} onChange={this.handleChange} />
                    </label><br />
                    <label>
                        <b>Payback time (months)</b><br />
                        <input name="months" type="number" value={this.state.months} onChange={this.handleChange} />
                    </label><br />
                    <input type="submit" value="Submit" />
                </form>
                {content}
            </>
        );
    }
}
