import Navbar from 'react-bootstrap/Navbar';

function NavBar() {
    return (
        <Navbar expand="lg" className="bg-body-tertiary justify-content-center">
            <div className="d-flex align-items-center">
                <img
                    src="https://mf.gov.md/sites/default/files/01_logo_0.png"
                    alt="Ministerul Finanțelor Logo"
                />
                <h1 style={{ marginLeft: "10px" }}>Ministerul Finanțelor</h1>
                <img
                    src="https://mf.gov.md/sites/default/files/ader%20UE.jpg"
                    alt="Ministerul Finanțelor Logo"
                />
            </div>
        </Navbar>
    );
}

export default NavBar;