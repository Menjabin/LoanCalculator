import React, { Component } from 'react';

export class RepaymentPlan extends Component {
    static displayName = RepaymentPlan.name;

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
                        <th>Due Date</th>
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
                            <td>{Math.round(installment.amount)} kr</td>
                            <td>{Math.round(installment.principal)} kr</td>
                            <td>{Math.round(installment.interest)} kr</td>
                            <td>{Math.round(installment.remainingDebt)} kr</td>
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
            : RepaymentPlan.renderLoanTable(this.state.loan.installments);

        return (
            <div class="repayment">
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
