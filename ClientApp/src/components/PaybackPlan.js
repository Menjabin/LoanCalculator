import React, { Component } from 'react';

export class PaybackPlan extends Component {
    static displayName = PaybackPlan.name;

    constructor(props) {
        super(props);
        this.state = { installments: [], loading: true };
    }

    componentDidMount() {
        this.populateLoanData();
    }

    static renderLoanTable(installments) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Amount</th>
                        <th>Principal</th>
                        <th>Interest</th>
                        <th>Remaining Debt</th>
                    </tr>
                </thead>
                <tbody>
                    {installments.map(installment =>
                        <tr key={installment.date}>
                            <td>{installment.date}</td>
                            <td>{installment.amount}</td>
                            <td>{installment.principal}</td>
                            <td>{installment.interest}</td>
                            <td>{installment.remainingDebt}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : PaybackPlan.renderLoanTable(this.state.loan);

        return (
            <div>
                <p>With a rate of {this.props.rate}%, your payback plan will look something like this:</p>
                {contents}
            </div>
        );
    }

    async populateLoanData() {
        let url = "https://serialloanapi.azurewebsites.net/";
        let request = url + 'Loan?amount=' + this.props.amount + '&rate=' + this.props.rate + '&months=' + this.props.months;
        const response = await fetch(request);
        const data = await response.json();
        this.setState({ loan: data, loading: false });
    }
}
