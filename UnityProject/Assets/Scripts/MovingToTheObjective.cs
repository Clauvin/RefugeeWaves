using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToTheObjective : MonoBehaviour {

    [System.Serializable]
    public class ToTheObjectiveSavePackage
    {
        public Vector3 _initial_position;
        public Vector3 _final_objective;
        public float _time_to_reach_objective;
        public float _passed_time;

        private float _time_counted;
    }

    public ToTheObjectiveSavePackage to_the_objective_save_package;

    public ToTheObjectiveSavePackage GetToTheObjectiveSavePackage()
    {
        return to_the_objective_save_package;
    }

    public void SetToTheObjectiveSavePackage(ToTheObjectiveSavePackage save_package)
    {
        to_the_objective_save_package = save_package;
    }

    #region Public Variables
    public Vector3 initial_position {
        get { return to_the_objective_save_package._initial_position; }
        set { to_the_objective_save_package._initial_position = value; }
    }

    public Vector3 final_objective {
        get { return to_the_objective_save_package._final_objective; }
        set { to_the_objective_save_package._final_objective = value; }
    }

    public float time_to_reach_objective {
        get { return to_the_objective_save_package._time_to_reach_objective; }
        set { to_the_objective_save_package._time_to_reach_objective = value; }
    }

    public float passed_time {
        get { return to_the_objective_save_package._passed_time; }
        set { to_the_objective_save_package._passed_time = value; }
    }
    #endregion

    private float time_counted;

	// Use this for initialization
	void Start () {
        //to_the_objective_save_package = new ToTheObjectiveSavePackage();
        initial_position = new Vector2(transform.position.x, transform.position.y);
        passed_time = 0;
        time_counted = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (!TimeManager.instance.gamePaused) { 

            passed_time += Time.time - time_counted;
            time_counted = Time.time;
            transform.position = Vector3.Lerp(initial_position, final_objective, passed_time / time_to_reach_objective);

            if (passed_time / time_to_reach_objective >= 1.0f)
            {
                ImmigrantManager.instance.WaveReceived(this.gameObject);
                Destroy(this.gameObject);
            }

        }
    }
}
