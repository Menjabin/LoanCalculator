import React, { Component } from 'react';

export class Loan extends Component {
    static displayName = Loan.name;

    constructor(props) {
        super(props);
        this.state = { loan: [], loading: true };
    }

    componentDidMount() {
        this.populateLoanData();
    }

    static renderLoanTable(loan) {
        return (
            <div>
                <p>{loan.amount}</p>
                <p>{loan.rate}</p>
                <p>{loan.monthsToPay}</p>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Loan.renderLoanTable(this.state.loan);

        return (
            <div>
                <h1 id="tabelLabel">Loan calculator</h1>
                <p>This component demonstrates calculating a monthly payback plan for a housing loan.</p>
                {contents}
            </div>
        );
    }

    async populateLoanData() {
        const response = await fetch('loan');
        const data = await response.json();
        this.setState({ loan: data, loading: false });
    }
}
