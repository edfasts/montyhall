import 'bootstrap/dist/css/bootstrap.min.css';
import React, {useEffect, useState} from 'react';
import {Button, Form, Jumbotron, Table} from "react-bootstrap";

const API_HOST = "http://localhost:5080";
const SIMULATION_API_URL = `${API_HOST}/api/Simulation`;

function App() {
    const [data, setData] = useState([]);
    const [numberOfRounds, setNumberOfRounds] = useState(0);
    const [changeDoor, setChangeDoor] = useState(false);

    const fetchSimulations = async () => {
        const response = await fetch(`${SIMULATION_API_URL}`);
        const json = await response.json();
        setData(json);
        //.then(res => res.json())
        //.then(json => setData(json));
    }

    useEffect(() => {
        fetchSimulations();
    }, [data]);

    const handleTextChange = (event) => {
        setNumberOfRounds(event.target.value);
    }
    const handleCheckBoxClick = (event) => {
        setChangeDoor(event.target.checked);
    }
    const handleSubmit = async (event) => {
        event.preventDefault();
        await fetch(`${SIMULATION_API_URL}?numberOfRounds=${numberOfRounds}&changeDoor=${changeDoor}`,
            {method: 'POST'}); //.then(res => res.json());
    }
    return (
        <div className="container">
            <Jumbotron>
                <h1>Monty Hall</h1>
                <p>This application simulates the Monty Hall paradox.</p>
                <p>
                    <Button variant="primary" href={'https://en.wikipedia.org/wiki/Monty_Hall_problem'}>Learn
                        more</Button>
                </p>
                <p>Enter the number of game rounds to simulate, and whether to change the initially chosen door.
                    The expected result for a simulation is ~33% when the initial door is kept, and ~66% when
                    changed</p>

            </Jumbotron>
            <Form onSubmit={handleSubmit}>
                <Form.Group controlId="formBasicNumberOfRounds">
                    <Form.Label>Number of Rounds</Form.Label>
                    <Form.Control onChange={handleTextChange}/>
                    <Form.Text className="text-muted">
                        Enter the number of rounds that will be used in the simulation
                    </Form.Text>
                    <Form.Group controlId="formBasicCheckbox">
                        <Form.Check type="checkbox" label="Change door" onChange={handleCheckBoxClick}/>
                    </Form.Group>
                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form.Group>
            </Form>
            <h1>Simulations</h1>
            <Table striped bordered>
                <thead>
                <tr>
                    <th>Number of rounds</th>
                    <th>Successful rounds</th>
                    <th>Success rate</th>
                    <th>Change door</th>
                </tr>
                </thead>
                <tbody>
                {
                    data.map((item) => (
                        <tr key={item.id}>
                            <td>{item.numberOfRounds}</td>
                            <td>{item.successfulRounds}</td>
                            <td>{100 * item.successfulRounds / item.numberOfRounds} %</td>
                            <td>{item.changeDoor.toString()}</td>
                        </tr>
                    ))
                }
                </tbody>
            </Table>
        </div>
    );
}

export default App;
