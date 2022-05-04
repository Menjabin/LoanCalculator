import React, { Component } from 'react';

export class PaybackPlan extends Component {
    static displayName = PaybackPlan.name;

    constructor(props) {
        super(props);
        this.state = { loan: [], loading: true };
    }

    // Fetch data upon mounting this component
    componentDidMount() {
        this.populateLoanData();
    }

    componentDidUpdate(prevProps, prevState) {
        let update = false;

        // Only fetch new data if a prop has changed
        Object.entries(this.props).forEach(([key, val]) =>
            prevProps[key] !== val && (update = true)
        );

        if (update) {
            this.populateLoanData();
        }
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
                            <td>{installment.amount} kr</td>
                            <td>{installment.principal} kr</td>
                            <td>{installment.interest} kr</td>
                            <td>{installment.remainingDebt} kr</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        // Show "Loading..." if we are still waiting for data
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : PaybackPlan.renderLoanTable(this.state.loan.installments);

        return (
            <div>
                <p>With a rate of 3.5%, your payback plan will look something like this:</p>
                {contents}
            </div>
        );
    }

    async populateLoanData() {
        let request = 'loan/mortgage?amount=' + this.props.amount + '&years=' + this.props.years;
        const response = await fetch(request);
        const data = await response.json();
        this.setState({ loan: data, loading: false });
    }
}
